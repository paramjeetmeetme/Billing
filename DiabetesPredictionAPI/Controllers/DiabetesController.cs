using DiabetesPredictionAPI.Models;
using DiabetesPredictionAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DiabetesPredictionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DiabetesController : ControllerBase
    {
        private readonly DiabetesPredictionService _predictionService;
        private readonly ILogger<DiabetesController> _logger;

        public DiabetesController(DiabetesPredictionService predictionService, ILogger<DiabetesController> logger)
        {
            _predictionService = predictionService;
            _logger = logger;
        }

        /// <summary>
        /// Health check endpoint
        /// </summary>
        /// <returns>API status and ML API health</returns>
        [HttpGet("health")]
        [ProducesResponseType(typeof(object), 200)]
        public async Task<IActionResult> HealthCheck()
        {
            try
            {
                var mlApiHealthy = await _predictionService.IsHealthyAsync();
                
                var response = new
                {
                    status = "healthy",
                    timestamp = DateTime.UtcNow,
                    dotnetApi = "running",
                    mlApi = mlApiHealthy ? "healthy" : "unhealthy",
                    version = "1.0.0"
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Health check failed");
                return StatusCode(500, new { error = "Health check failed", details = ex.Message });
            }
        }

        /// <summary>
        /// Predict diabetes for a single patient
        /// </summary>
        /// <param name="patientData">Patient health data</param>
        /// <returns>Diabetes prediction result</returns>
        [HttpPost("predict")]
        [ProducesResponseType(typeof(PredictionResponse), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse), 500)]
        public async Task<IActionResult> PredictDiabetes([FromBody] DiabetesPatientData patientData)
        {
            try
            {
                // Validate input
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(x => x.Value?.Errors.Count > 0)
                        .SelectMany(x => x.Value!.Errors)
                        .Select(x => x.ErrorMessage);
                    
                    _logger.LogWarning("Invalid input data: {Errors}", string.Join(", ", errors));
                    return BadRequest(new ApiErrorResponse 
                    { 
                        Error = "Invalid input data", 
                        Details = string.Join(", ", errors) 
                    });
                }

                _logger.LogInformation("Processing diabetes prediction for patient");

                var result = await _predictionService.PredictDiabetesAsync(patientData);

                if (result == null)
                {
                    _logger.LogError("Prediction service returned null result");
                    return StatusCode(500, new ApiErrorResponse 
                    { 
                        Error = "Prediction failed", 
                        Details = "The ML service is currently unavailable" 
                    });
                }

                _logger.LogInformation("Prediction completed successfully: {Result}", result.PredictionText);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during diabetes prediction");
                return StatusCode(500, new ApiErrorResponse 
                { 
                    Error = "Internal server error", 
                    Details = ex.Message 
                });
            }
        }

        /// <summary>
        /// Upload CSV file and get diabetes predictions for multiple patients
        /// </summary>
        /// <param name="file">CSV file containing patient data</param>
        /// <returns>Prediction results for all patients in CSV</returns>
        [HttpPost("predict-csv")]
        [ProducesResponseType(typeof(CsvPredictionResponse), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse), 500)]
        public async Task<IActionResult> PredictFromCsv([Required] IFormFile file)
        {
            try
            {
                // Validate file
                if (file == null || file.Length == 0)
                {
                    _logger.LogWarning("No file uploaded or empty file");
                    return BadRequest(new ApiErrorResponse 
                    { 
                        Error = "No file provided", 
                        Details = "Please upload a valid CSV file" 
                    });
                }

                if (!file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    _logger.LogWarning("Invalid file type uploaded: {FileName}", file.FileName);
                    return BadRequest(new ApiErrorResponse 
                    { 
                        Error = "Invalid file type", 
                        Details = "Only CSV files are supported" 
                    });
                }

                if (file.Length > 10 * 1024 * 1024) // 10MB limit
                {
                    _logger.LogWarning("File too large: {Size} bytes", file.Length);
                    return BadRequest(new ApiErrorResponse 
                    { 
                        Error = "File too large", 
                        Details = "File size must be less than 10MB" 
                    });
                }

                _logger.LogInformation("Processing CSV file: {FileName}, Size: {Size} bytes", file.FileName, file.Length);

                using var stream = file.OpenReadStream();
                var result = await _predictionService.PredictFromCsvAsync(stream, file.FileName);

                if (result == null)
                {
                    _logger.LogError("CSV prediction service returned null result");
                    return StatusCode(500, new ApiErrorResponse 
                    { 
                        Error = "CSV prediction failed", 
                        Details = "The ML service is currently unavailable or the CSV format is invalid" 
                    });
                }

                _logger.LogInformation("CSV processing completed successfully. Total patients: {Count}", result.Summary?.TotalPatients);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during CSV prediction");
                return StatusCode(500, new ApiErrorResponse 
                { 
                    Error = "Internal server error", 
                    Details = ex.Message 
                });
            }
        }

        /// <summary>
        /// Get information about the ML model
        /// </summary>
        /// <returns>Model information including features and descriptions</returns>
        [HttpGet("model-info")]
        [ProducesResponseType(typeof(ModelInfoResponse), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 500)]
        public async Task<IActionResult> GetModelInfo()
        {
            try
            {
                _logger.LogInformation("Fetching model information");

                var result = await _predictionService.GetModelInfoAsync();

                if (result == null)
                {
                    _logger.LogError("Model info service returned null result");
                    return StatusCode(500, new ApiErrorResponse 
                    { 
                        Error = "Failed to retrieve model info", 
                        Details = "The ML service is currently unavailable" 
                    });
                }

                _logger.LogInformation("Model info retrieved successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching model info");
                return StatusCode(500, new ApiErrorResponse 
                { 
                    Error = "Internal server error", 
                    Details = ex.Message 
                });
            }
        }

        /// <summary>
        /// Generate sample patient data for testing
        /// </summary>
        /// <returns>Sample patient data</returns>
        [HttpGet("sample-data")]
        [ProducesResponseType(typeof(DiabetesPatientData), 200)]
        public IActionResult GetSampleData()
        {
            var sampleData = new DiabetesPatientData
            {
                Pregnancies = 6,
                Glucose = 148,
                BloodPressure = 72,
                SkinThickness = 35,
                Insulin = 0,
                BMI = 33.6f,
                DiabetesPedigreeFunction = 0.627f,
                Age = 50
            };

            return Ok(sampleData);
        }

        /// <summary>
        /// Get API documentation and usage examples
        /// </summary>
        /// <returns>API documentation</returns>
        [HttpGet("docs")]
        [ProducesResponseType(typeof(object), 200)]
        public IActionResult GetDocumentation()
        {
            var documentation = new
            {
                title = "Diabetes Prediction API",
                version = "1.0.0",
                description = "API for predicting diabetes using machine learning",
                endpoints = new
                {
                    health = new
                    {
                        method = "GET",
                        path = "/api/diabetes/health",
                        description = "Check API and ML service health"
                    },
                    predict = new
                    {
                        method = "POST",
                        path = "/api/diabetes/predict",
                        description = "Predict diabetes for a single patient",
                        requestBody = "DiabetesPatientData object"
                    },
                    predictCsv = new
                    {
                        method = "POST",
                        path = "/api/diabetes/predict-csv",
                        description = "Upload CSV file and get predictions for multiple patients",
                        requestBody = "multipart/form-data with CSV file"
                    },
                    modelInfo = new
                    {
                        method = "GET",
                        path = "/api/diabetes/model-info",
                        description = "Get information about the ML model"
                    },
                    sampleData = new
                    {
                        method = "GET",
                        path = "/api/diabetes/sample-data",
                        description = "Get sample patient data for testing"
                    }
                },
                features = new[]
                {
                    "Pregnancies: Number of times pregnant",
                    "Glucose: Plasma glucose concentration",
                    "BloodPressure: Diastolic blood pressure (mm Hg)",
                    "SkinThickness: Triceps skin fold thickness (mm)",
                    "Insulin: 2-Hour serum insulin (mu U/ml)",
                    "BMI: Body mass index",
                    "DiabetesPedigreeFunction: Diabetes pedigree function",
                    "Age: Age (years)"
                }
            };

            return Ok(documentation);
        }
    }
}