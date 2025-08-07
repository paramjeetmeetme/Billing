from flask import Flask, request, jsonify
from flask_cors import CORS
import pandas as pd
import numpy as np
import joblib
import os
from werkzeug.utils import secure_filename
import tempfile
from diabetes_model import DiabetesPredictionModel

app = Flask(__name__)
CORS(app)  # Enable CORS for .NET Core client

# Configuration
UPLOAD_FOLDER = '/tmp'
ALLOWED_EXTENSIONS = {'csv'}
app.config['UPLOAD_FOLDER'] = UPLOAD_FOLDER
app.config['MAX_CONTENT_LENGTH'] = 16 * 1024 * 1024  # 16MB max file size

# Initialize the model
diabetes_model = DiabetesPredictionModel()

def allowed_file(filename):
    return '.' in filename and filename.rsplit('.', 1)[1].lower() in ALLOWED_EXTENSIONS

@app.route('/', methods=['GET'])
def home():
    """Health check endpoint"""
    return jsonify({
        'message': 'Diabetes Prediction API is running!',
        'version': '1.0.0',
        'endpoints': {
            'predict': '/predict - POST with JSON data',
            'predict_csv': '/predict_csv - POST with CSV file',
            'health': '/ - GET health check'
        }
    })

@app.route('/predict', methods=['POST'])
def predict_diabetes():
    """Predict diabetes for a single patient"""
    try:
        # Get JSON data from request
        data = request.get_json()
        
        if not data:
            return jsonify({'error': 'No data provided'}), 400
        
        # Expected features
        required_features = [
            'Pregnancies', 'Glucose', 'BloodPressure', 'SkinThickness',
            'Insulin', 'BMI', 'DiabetesPedigreeFunction', 'Age'
        ]
        
        # Check if all required features are present
        if not all(feature in data for feature in required_features):
            return jsonify({
                'error': 'Missing required features',
                'required_features': required_features,
                'provided_features': list(data.keys())
            }), 400
        
        # Extract feature values
        patient_data = [data[feature] for feature in required_features]
        
        # Make prediction
        result = diabetes_model.predict_single(patient_data)
        
        if result is None:
            return jsonify({'error': 'Prediction failed'}), 500
        
        # Add input data to response
        response = {
            'input_data': dict(zip(required_features, patient_data)),
            'prediction': result['prediction'],
            'prediction_text': 'Diabetes' if result['prediction'] == 1 else 'No Diabetes',
            'probability_no_diabetes': result['probability_no_diabetes'],
            'probability_diabetes': result['probability_diabetes'],
            'risk_level': result['risk_level'],
            'confidence': max(result['probability_no_diabetes'], result['probability_diabetes'])
        }
        
        return jsonify(response)
        
    except Exception as e:
        return jsonify({'error': f'Prediction error: {str(e)}'}), 500

@app.route('/predict_csv', methods=['POST'])
def predict_diabetes_csv():
    """Predict diabetes for multiple patients from CSV file"""
    try:
        # Check if file is present
        if 'file' not in request.files:
            return jsonify({'error': 'No file provided'}), 400
        
        file = request.files['file']
        
        if file.filename == '':
            return jsonify({'error': 'No file selected'}), 400
        
        if not allowed_file(file.filename):
            return jsonify({'error': 'File type not allowed. Please upload a CSV file.'}), 400
        
        # Save the uploaded file temporarily
        filename = secure_filename(file.filename)
        temp_path = os.path.join(app.config['UPLOAD_FOLDER'], filename)
        file.save(temp_path)
        
        try:
            # Make predictions
            results = diabetes_model.predict_from_csv(temp_path)
            
            if results is None:
                return jsonify({'error': 'Failed to process CSV file'}), 500
            
            # Convert results to JSON format
            predictions = []
            for index, row in results.iterrows():
                predictions.append({
                    'row_index': int(index),
                    'input_data': {
                        'Pregnancies': row['Pregnancies'],
                        'Glucose': row['Glucose'],
                        'BloodPressure': row['BloodPressure'],
                        'SkinThickness': row['SkinThickness'],
                        'Insulin': row['Insulin'],
                        'BMI': row['BMI'],
                        'DiabetesPedigreeFunction': row['DiabetesPedigreeFunction'],
                        'Age': row['Age']
                    },
                    'prediction': int(row['Prediction']),
                    'prediction_text': 'Diabetes' if row['Prediction'] == 1 else 'No Diabetes',
                    'probability_no_diabetes': float(row['Probability_No_Diabetes']),
                    'probability_diabetes': float(row['Probability_Diabetes']),
                    'risk_level': row['Risk_Level'],
                    'confidence': float(max(row['Probability_No_Diabetes'], row['Probability_Diabetes']))
                })
            
            # Summary statistics
            total_patients = len(predictions)
            diabetes_cases = sum(1 for p in predictions if p['prediction'] == 1)
            no_diabetes_cases = total_patients - diabetes_cases
            
            response = {
                'summary': {
                    'total_patients': total_patients,
                    'diabetes_cases': diabetes_cases,
                    'no_diabetes_cases': no_diabetes_cases,
                    'diabetes_percentage': round((diabetes_cases / total_patients) * 100, 2) if total_patients > 0 else 0
                },
                'predictions': predictions
            }
            
            return jsonify(response)
            
        finally:
            # Clean up temporary file
            if os.path.exists(temp_path):
                os.remove(temp_path)
        
    except Exception as e:
        return jsonify({'error': f'CSV processing error: {str(e)}'}), 500

@app.route('/model_info', methods=['GET'])
def model_info():
    """Get information about the model"""
    return jsonify({
        'model_type': 'Random Forest Classifier',
        'features': diabetes_model.feature_names,
        'feature_descriptions': {
            'Pregnancies': 'Number of times pregnant',
            'Glucose': 'Plasma glucose concentration a 2 hours in an oral glucose tolerance test',
            'BloodPressure': 'Diastolic blood pressure (mm Hg)',
            'SkinThickness': 'Triceps skin fold thickness (mm)',
            'Insulin': '2-Hour serum insulin (mu U/ml)',
            'BMI': 'Body mass index (weight in kg/(height in m)^2)',
            'DiabetesPedigreeFunction': 'Diabetes pedigree function',
            'Age': 'Age (years)'
        },
        'prediction_classes': {
            0: 'No Diabetes',
            1: 'Diabetes'
        }
    })

def initialize_model():
    """Initialize the model on startup"""
    try:
        # Check if model files exist
        if os.path.exists('diabetes_model.pkl') and os.path.exists('diabetes_scaler.pkl'):
            diabetes_model.load_model()
            print("Model loaded successfully!")
        else:
            print("Model files not found. Training new model...")
            # Load data and train model
            diabetes_model.load_data('diabetes_data.csv')
            diabetes_model.train_model()
            diabetes_model.save_model()
            print("New model trained and saved!")
    except Exception as e:
        print(f"Error initializing model: {e}")

if __name__ == '__main__':
    # Initialize model on startup
    initialize_model()
    
    # Run the Flask app
    print("Starting Diabetes Prediction API...")
    print("API will be available at: http://localhost:5000")
    print("Endpoints:")
    print("  GET  /           - Health check")
    print("  POST /predict    - Single prediction")
    print("  POST /predict_csv - CSV file prediction")
    print("  GET  /model_info - Model information")
    
    app.run(host='0.0.0.0', port=5000, debug=False)