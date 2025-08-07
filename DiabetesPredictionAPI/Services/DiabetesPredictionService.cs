using DiabetesPredictionAPI.Models;
using System.Text;
using System.Text.Json;

namespace DiabetesPredictionAPI.Services
{
    /// <summary>
    /// Service for communicating with the Python ML prediction API
    /// </summary>
    public class DiabetesPredictionService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DiabetesPredictionService> _logger;
        private readonly string _mlApiBaseUrl;

        public DiabetesPredictionService(HttpClient httpClient, ILogger<DiabetesPredictionService> logger, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _logger = logger;
            _mlApiBaseUrl = configuration["MLApiSettings:BaseUrl"] ?? "http://localhost:5000";
            
            // Configure HttpClient
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        /// <summary>
        /// Predict diabetes for a single patient
        /// </summary>
        /// <param name="patientData">Patient health data</param>
        /// <returns>Prediction result</returns>
        public async Task<PredictionResponse?> PredictDiabetesAsync(DiabetesPatientData patientData)
        {
            try
            {
                _logger.LogInformation("Making prediction for patient data");

                var jsonData = JsonSerializer.Serialize(patientData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_mlApiBaseUrl}/predict", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<PredictionResponse>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    _logger.LogInformation("Prediction successful: {Prediction}", result?.PredictionText);
                    return result;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError("ML API returned error: {StatusCode} - {Content}", response.StatusCode, errorContent);
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed while calling ML API");
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "JSON serialization/deserialization failed");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred during prediction");
                return null;
            }
        }

        /// <summary>
        /// Upload CSV file and get predictions for multiple patients
        /// </summary>
        /// <param name="csvFileStream">CSV file stream</param>
        /// <param name="fileName">Original file name</param>
        /// <returns>CSV prediction results</returns>
        public async Task<CsvPredictionResponse?> PredictFromCsvAsync(Stream csvFileStream, string fileName)
        {
            try
            {
                _logger.LogInformation("Processing CSV file: {FileName}", fileName);

                using var formData = new MultipartFormDataContent();
                using var streamContent = new StreamContent(csvFileStream);
                streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/csv");
                formData.Add(streamContent, "file", fileName);

                var response = await _httpClient.PostAsync($"{_mlApiBaseUrl}/predict_csv", formData);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<CsvPredictionResponse>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    _logger.LogInformation("CSV processing successful. Total patients: {Count}", result?.Summary?.TotalPatients);
                    return result;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError("ML API returned error for CSV: {StatusCode} - {Content}", response.StatusCode, errorContent);
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed while uploading CSV to ML API");
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "JSON deserialization failed for CSV response");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred during CSV processing");
                return null;
            }
        }

        /// <summary>
        /// Get model information from the ML API
        /// </summary>
        /// <returns>Model information</returns>
        public async Task<ModelInfoResponse?> GetModelInfoAsync()
        {
            try
            {
                _logger.LogInformation("Fetching model information");

                var response = await _httpClient.GetAsync($"{_mlApiBaseUrl}/model_info");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<ModelInfoResponse>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    _logger.LogInformation("Model info retrieved successfully");
                    return result;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError("ML API returned error for model info: {StatusCode} - {Content}", response.StatusCode, errorContent);
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed while getting model info");
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "JSON deserialization failed for model info");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while getting model info");
                return null;
            }
        }

        /// <summary>
        /// Check if the ML API is healthy
        /// </summary>
        /// <returns>True if API is healthy, false otherwise</returns>
        public async Task<bool> IsHealthyAsync()
        {
            try
            {
                _logger.LogInformation("Checking ML API health");

                var response = await _httpClient.GetAsync($"{_mlApiBaseUrl}/");
                
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("ML API is healthy");
                    return true;
                }
                else
                {
                    _logger.LogWarning("ML API health check failed with status: {StatusCode}", response.StatusCode);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ML API health check failed");
                return false;
            }
        }
    }
}