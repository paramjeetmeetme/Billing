# Diabetes Prediction System

A comprehensive diabetes prediction system built with Python machine learning and .NET Core Web API. This system provides diabetes risk prediction based on patient health data using a Random Forest classifier.

## 🏗️ Architecture

```
┌─────────────────┐    HTTP    ┌─────────────────┐    HTTP    ┌─────────────────┐
│                 │  Requests  │                 │  Requests  │                 │
│   Client App    │ ────────── │  .NET Core API  │ ────────── │  Python ML API  │
│                 │            │                 │            │                 │
└─────────────────┘            └─────────────────┘            └─────────────────┘
                                        │                               │
                                        │                               │
                                   ┌─────────┐                   ┌─────────────┐
                                   │ Swagger │                   │ ML Model    │
                                   │   UI    │                   │ (.pkl files)│
                                   └─────────┘                   └─────────────┘
```

## 📋 Features

### Machine Learning Model
- **Algorithm**: Random Forest Classifier
- **Accuracy**: ~84% on test data
- **Features**: 8 health indicators (Pregnancies, Glucose, Blood Pressure, etc.)
- **Training Data**: 370 patient records with realistic dummy values
- **Model Persistence**: Saved using joblib for fast loading

### Python Flask API
- **Single Prediction**: POST `/predict` - Predict diabetes for one patient
- **Batch Prediction**: POST `/predict_csv` - Upload CSV file for multiple predictions
- **Model Info**: GET `/model_info` - Get model details and feature descriptions
- **Health Check**: GET `/` - API status check
- **CORS Enabled**: Cross-origin requests supported

### .NET Core Web API
- **RESTful API**: Full CRUD operations with proper HTTP status codes
- **Swagger Documentation**: Interactive API documentation
- **Input Validation**: Comprehensive data validation with meaningful error messages
- **File Upload**: CSV file processing with size and type validation
- **Health Monitoring**: ML API connectivity checks
- **Logging**: Structured logging with different levels
- **Error Handling**: Graceful error handling with detailed responses

## 🚀 Quick Start

### Prerequisites
- Python 3.8+ with pip
- .NET 8.0 SDK (optional, for running .NET API)
- Git (for cloning the repository)

### 1. Start the Python ML API

```bash
# Navigate to project directory
cd /workspace

# Run the startup script
./start_ml_api.sh

# Or manually:
pip3 install --break-system-packages -r requirements.txt
python3 app.py
```

The ML API will start on `http://localhost:5000`

### 2. Start the .NET Core API (Optional)

```bash
# Run the startup script
./start_dotnet_api.sh

# Or manually:
cd DiabetesPredictionAPI
dotnet restore
dotnet build
dotnet run
```

The .NET API will start on `http://localhost:7000`

## 📊 Dataset

The system uses a diabetes dataset with the following features:

| Feature | Description | Range |
|---------|-------------|-------|
| **Pregnancies** | Number of times pregnant | 0-20 |
| **Glucose** | Plasma glucose concentration | 50-300 mg/dL |
| **BloodPressure** | Diastolic blood pressure | 40-150 mmHg |
| **SkinThickness** | Triceps skin fold thickness | 0-100 mm |
| **Insulin** | 2-Hour serum insulin | 0-1000 μU/mL |
| **BMI** | Body mass index | 10-70 kg/m² |
| **DiabetesPedigreeFunction** | Diabetes pedigree function | 0-5 |
| **Age** | Age in years | 18-120 |

## 🔌 API Endpoints

### Python ML API (Port 5000)

#### Health Check
```http
GET http://localhost:5000/
```

#### Single Prediction
```http
POST http://localhost:5000/predict
Content-Type: application/json

{
  "Pregnancies": 6,
  "Glucose": 148,
  "BloodPressure": 72,
  "SkinThickness": 35,
  "Insulin": 0,
  "BMI": 33.6,
  "DiabetesPedigreeFunction": 0.627,
  "Age": 50
}
```

#### CSV Prediction
```http
POST http://localhost:5000/predict_csv
Content-Type: multipart/form-data

file: [CSV file with patient data]
```

#### Model Information
```http
GET http://localhost:5000/model_info
```

### .NET Core API (Port 7000)

#### API Documentation
```http
GET http://localhost:7000/swagger
```

#### Health Check
```http
GET http://localhost:7000/api/diabetes/health
```

#### Single Prediction
```http
POST http://localhost:7000/api/diabetes/predict
Content-Type: application/json

{
  "pregnancies": 6,
  "glucose": 148,
  "bloodPressure": 72,
  "skinThickness": 35,
  "insulin": 0,
  "bmi": 33.6,
  "diabetesPedigreeFunction": 0.627,
  "age": 50
}
```

#### CSV Prediction
```http
POST http://localhost:7000/api/diabetes/predict-csv
Content-Type: multipart/form-data

file: [CSV file with patient data]
```

#### Sample Data
```http
GET http://localhost:7000/api/diabetes/sample-data
```

## 📝 Example Usage

### 1. Single Patient Prediction (Python API)

```bash
curl -X POST http://localhost:5000/predict \
  -H "Content-Type: application/json" \
  -d '{
    "Pregnancies": 1,
    "Glucose": 89,
    "BloodPressure": 66,
    "SkinThickness": 23,
    "Insulin": 94,
    "BMI": 28.1,
    "DiabetesPedigreeFunction": 0.167,
    "Age": 21
  }'
```

**Response:**
```json
{
  "input_data": {
    "Pregnancies": 1,
    "Glucose": 89,
    "BloodPressure": 66,
    "SkinThickness": 23,
    "Insulin": 94,
    "BMI": 28.1,
    "DiabetesPedigreeFunction": 0.167,
    "Age": 21
  },
  "prediction": 0,
  "prediction_text": "No Diabetes",
  "probability_no_diabetes": 0.85,
  "probability_diabetes": 0.15,
  "risk_level": "Low",
  "confidence": 0.85
}
```

### 2. CSV File Prediction

Create a CSV file (`test_patients.csv`) with patient data:
```csv
Pregnancies,Glucose,BloodPressure,SkinThickness,Insulin,BMI,DiabetesPedigreeFunction,Age
1,89,66,23,94,28.1,0.167,21
6,148,72,35,0,33.6,0.627,50
```

Upload via curl:
```bash
curl -X POST http://localhost:5000/predict_csv \
  -F "file=@test_patients.csv"
```

### 3. Using the .NET API with Swagger

1. Navigate to `http://localhost:7000/swagger`
2. Explore the interactive API documentation
3. Test endpoints directly from the browser
4. View request/response schemas

## 🔧 Configuration

### Python ML API Configuration

Edit `app.py` to configure:
- **Port**: Change the port in `app.run()`
- **Model Files**: Update model file paths
- **CORS Settings**: Modify CORS policy
- **File Upload Limits**: Adjust max file size

### .NET Core API Configuration

Edit `appsettings.json`:
```json
{
  "MLApiSettings": {
    "BaseUrl": "http://localhost:5000",
    "TimeoutSeconds": 30,
    "RetryAttempts": 3
  },
  "ApiSettings": {
    "MaxFileSizeMB": 10,
    "AllowedFileTypes": ["csv"],
    "RateLimitRequests": 100,
    "RateLimitWindowMinutes": 15
  }
}
```

## 🏥 Model Performance

The Random Forest model achieves the following performance metrics:

- **Accuracy**: 83.78%
- **Precision**: 84% (No Diabetes), 83% (Diabetes)
- **Recall**: 91% (No Diabetes), 71% (Diabetes)
- **F1-Score**: 88% (No Diabetes), 77% (Diabetes)

### Feature Importance
1. **Glucose** (27.13%) - Most important predictor
2. **BMI** (15.96%) - Second most important
3. **DiabetesPedigreeFunction** (13.19%)
4. **Age** (11.80%)
5. **Insulin** (10.20%)
6. **BloodPressure** (8.15%)
7. **Pregnancies** (7.68%)
8. **SkinThickness** (5.89%)

## 🐛 Troubleshooting

### Common Issues

1. **Python Dependencies Missing**
   ```bash
   pip3 install --break-system-packages pandas numpy scikit-learn flask flask-cors joblib
   ```

2. **Model Files Not Found**
   ```bash
   python3 diabetes_model.py
   ```

3. **.NET SDK Not Installed**
   - Download from [dotnet.microsoft.com](https://dotnet.microsoft.com/download)
   - Follow installation instructions for your OS

4. **Port Already in Use**
   - Change ports in configuration files
   - Kill existing processes: `lsof -ti:5000 | xargs kill -9`

5. **CORS Issues**
   - Ensure CORS is enabled in both APIs
   - Check browser console for specific errors

### Logging

- **Python API**: Logs are printed to console
- **.NET API**: Structured logging to console and debug output

## 📦 Project Structure

```
/workspace
├── diabetes_data.csv              # Training dataset
├── diabetes_model.py              # ML model training script
├── diabetes_model.pkl             # Trained model (generated)
├── diabetes_scaler.pkl            # Feature scaler (generated)
├── app.py                         # Python Flask API
├── requirements.txt               # Python dependencies
├── sample_patients.csv            # Sample test data
├── start_ml_api.sh               # ML API startup script
├── start_dotnet_api.sh           # .NET API startup script
├── DiabetesPredictionAPI/        # .NET Core project
│   ├── Controllers/
│   │   └── DiabetesController.cs
│   ├── Models/
│   │   └── DiabetesData.cs
│   ├── Services/
│   │   └── DiabetesPredictionService.cs
│   ├── Program.cs
│   ├── appsettings.json
│   └── DiabetesPredictionAPI.csproj
└── README.md                     # This documentation
```

## 🚀 Deployment

### Production Considerations

1. **Security**
   - Add authentication/authorization
   - Use HTTPS in production
   - Implement rate limiting
   - Validate and sanitize all inputs

2. **Scalability**
   - Use load balancers for multiple instances
   - Implement caching for frequent predictions
   - Consider async processing for large CSV files

3. **Monitoring**
   - Add health checks and metrics
   - Implement proper logging and alerting
   - Monitor model performance over time

4. **Docker Deployment**
   ```dockerfile
   # Example Dockerfile for Python API
   FROM python:3.9-slim
   COPY requirements.txt .
   RUN pip install -r requirements.txt
   COPY . .
   EXPOSE 5000
   CMD ["python", "app.py"]
   ```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests for new functionality
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License. See LICENSE file for details.

## 📞 Support

For support and questions:
- Create an issue on GitHub
- Check the troubleshooting section
- Review the API documentation

---

**Note**: This system is for educational/demonstration purposes. For production medical applications, ensure proper validation, testing, and regulatory compliance.