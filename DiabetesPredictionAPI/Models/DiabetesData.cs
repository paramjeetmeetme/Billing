using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DiabetesPredictionAPI.Models
{
    /// <summary>
    /// Represents diabetes patient data for prediction
    /// </summary>
    public class DiabetesPatientData
    {
        [JsonPropertyName("Pregnancies")]
        [Range(0, 20, ErrorMessage = "Pregnancies must be between 0 and 20")]
        public int Pregnancies { get; set; }

        [JsonPropertyName("Glucose")]
        [Range(50, 300, ErrorMessage = "Glucose must be between 50 and 300")]
        public float Glucose { get; set; }

        [JsonPropertyName("BloodPressure")]
        [Range(40, 150, ErrorMessage = "Blood pressure must be between 40 and 150")]
        public float BloodPressure { get; set; }

        [JsonPropertyName("SkinThickness")]
        [Range(0, 100, ErrorMessage = "Skin thickness must be between 0 and 100")]
        public float SkinThickness { get; set; }

        [JsonPropertyName("Insulin")]
        [Range(0, 1000, ErrorMessage = "Insulin must be between 0 and 1000")]
        public float Insulin { get; set; }

        [JsonPropertyName("BMI")]
        [Range(10, 70, ErrorMessage = "BMI must be between 10 and 70")]
        public float BMI { get; set; }

        [JsonPropertyName("DiabetesPedigreeFunction")]
        [Range(0, 5, ErrorMessage = "Diabetes pedigree function must be between 0 and 5")]
        public float DiabetesPedigreeFunction { get; set; }

        [JsonPropertyName("Age")]
        [Range(18, 120, ErrorMessage = "Age must be between 18 and 120")]
        public int Age { get; set; }
    }

    /// <summary>
    /// Represents the response from the ML prediction API
    /// </summary>
    public class PredictionResponse
    {
        [JsonPropertyName("input_data")]
        public Dictionary<string, object>? InputData { get; set; }

        [JsonPropertyName("prediction")]
        public int Prediction { get; set; }

        [JsonPropertyName("prediction_text")]
        public string PredictionText { get; set; } = string.Empty;

        [JsonPropertyName("probability_no_diabetes")]
        public float ProbabilityNoDiabetes { get; set; }

        [JsonPropertyName("probability_diabetes")]
        public float ProbabilityDiabetes { get; set; }

        [JsonPropertyName("risk_level")]
        public string RiskLevel { get; set; } = string.Empty;

        [JsonPropertyName("confidence")]
        public float Confidence { get; set; }
    }

    /// <summary>
    /// Response for CSV file predictions
    /// </summary>
    public class CsvPredictionResponse
    {
        [JsonPropertyName("summary")]
        public PredictionSummary? Summary { get; set; }

        [JsonPropertyName("predictions")]
        public List<PredictionResult>? Predictions { get; set; }
    }

    /// <summary>
    /// Summary of CSV predictions
    /// </summary>
    public class PredictionSummary
    {
        [JsonPropertyName("total_patients")]
        public int TotalPatients { get; set; }

        [JsonPropertyName("diabetes_cases")]
        public int DiabetesCases { get; set; }

        [JsonPropertyName("no_diabetes_cases")]
        public int NoDiabetesCases { get; set; }

        [JsonPropertyName("diabetes_percentage")]
        public float DiabetesPercentage { get; set; }
    }

    /// <summary>
    /// Individual prediction result
    /// </summary>
    public class PredictionResult
    {
        [JsonPropertyName("row_index")]
        public int RowIndex { get; set; }

        [JsonPropertyName("input_data")]
        public DiabetesPatientData? InputData { get; set; }

        [JsonPropertyName("prediction")]
        public int Prediction { get; set; }

        [JsonPropertyName("prediction_text")]
        public string PredictionText { get; set; } = string.Empty;

        [JsonPropertyName("probability_no_diabetes")]
        public float ProbabilityNoDiabetes { get; set; }

        [JsonPropertyName("probability_diabetes")]
        public float ProbabilityDiabetes { get; set; }

        [JsonPropertyName("risk_level")]
        public string RiskLevel { get; set; } = string.Empty;

        [JsonPropertyName("confidence")]
        public float Confidence { get; set; }
    }

    /// <summary>
    /// API error response
    /// </summary>
    public class ApiErrorResponse
    {
        [JsonPropertyName("error")]
        public string Error { get; set; } = string.Empty;

        [JsonPropertyName("details")]
        public string? Details { get; set; }
    }

    /// <summary>
    /// Model information response
    /// </summary>
    public class ModelInfoResponse
    {
        [JsonPropertyName("model_type")]
        public string ModelType { get; set; } = string.Empty;

        [JsonPropertyName("features")]
        public List<string>? Features { get; set; }

        [JsonPropertyName("feature_descriptions")]
        public Dictionary<string, string>? FeatureDescriptions { get; set; }

        [JsonPropertyName("prediction_classes")]
        public Dictionary<string, string>? PredictionClasses { get; set; }
    }
}