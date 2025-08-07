#!/bin/bash

# Start the ML API script

echo "Starting Diabetes Prediction ML API..."

# Check if Python 3 is available
if ! command -v python3 &> /dev/null; then
    echo "Error: Python 3 is not installed"
    exit 1
fi

# Check if required packages are installed
echo "Checking Python dependencies..."
python3 -c "import pandas, numpy, sklearn, flask, joblib" 2>/dev/null
if [ $? -ne 0 ]; then
    echo "Installing Python dependencies..."
    pip3 install --break-system-packages -r requirements.txt
    if [ $? -ne 0 ]; then
        echo "Error: Failed to install Python dependencies"
        exit 1
    fi
fi

# Check if model files exist
if [ ! -f "diabetes_model.pkl" ] || [ ! -f "diabetes_scaler.pkl" ]; then
    echo "Model files not found. Training new model..."
    python3 diabetes_model.py
    if [ $? -ne 0 ]; then
        echo "Error: Failed to train model"
        exit 1
    fi
fi

# Start the Flask API
echo "Starting Flask API on port 5000..."
export FLASK_APP=app.py
export FLASK_ENV=production
export PYTHONPATH="${PYTHONPATH}:$(pwd)"

python3 app.py

echo "ML API stopped."