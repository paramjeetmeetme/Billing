import pandas as pd
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler
from sklearn.ensemble import RandomForestClassifier
from sklearn.linear_model import LogisticRegression
from sklearn.metrics import accuracy_score, classification_report, confusion_matrix
import joblib
# import matplotlib.pyplot as plt
# import seaborn as sns

class DiabetesPredictionModel:
    def __init__(self):
        self.model = None
        self.scaler = StandardScaler()
        self.feature_names = [
            'Pregnancies', 'Glucose', 'BloodPressure', 'SkinThickness',
            'Insulin', 'BMI', 'DiabetesPedigreeFunction', 'Age'
        ]
        
    def load_data(self, file_path='diabetes_data.csv'):
        """Load the diabetes dataset"""
        try:
            self.data = pd.read_csv(file_path)
            print(f"Dataset loaded successfully! Shape: {self.data.shape}")
            return self.data
        except Exception as e:
            print(f"Error loading data: {e}")
            return None
    
    def explore_data(self):
        """Explore the dataset"""
        if self.data is not None:
            print("\n=== Dataset Info ===")
            print(self.data.info())
            print("\n=== Dataset Description ===")
            print(self.data.describe())
            print("\n=== Target Distribution ===")
            print(self.data['Outcome'].value_counts())
            print(f"Diabetes cases: {self.data['Outcome'].sum()}")
            print(f"Non-diabetes cases: {len(self.data) - self.data['Outcome'].sum()}")
    
    def preprocess_data(self):
        """Preprocess the data"""
        if self.data is None:
            print("No data loaded!")
            return None, None
        
        # Separate features and target
        X = self.data[self.feature_names]
        y = self.data['Outcome']
        
        # Handle missing values (replace 0s with median for certain features)
        features_to_replace_zeros = ['Glucose', 'BloodPressure', 'SkinThickness', 'Insulin', 'BMI']
        
        for feature in features_to_replace_zeros:
            if feature in X.columns:
                # Replace 0s with median (excluding 0s for calculation)
                median_value = X[X[feature] != 0][feature].median()
                X.loc[X[feature] == 0, feature] = median_value
        
        print("Data preprocessing completed!")
        return X, y
    
    def train_model(self, test_size=0.2, random_state=42):
        """Train the diabetes prediction model"""
        X, y = self.preprocess_data()
        
        if X is None or y is None:
            return
        
        # Split the data
        X_train, X_test, y_train, y_test = train_test_split(
            X, y, test_size=test_size, random_state=random_state, stratify=y
        )
        
        # Scale the features
        X_train_scaled = self.scaler.fit_transform(X_train)
        X_test_scaled = self.scaler.transform(X_test)
        
        # Train Random Forest model
        self.model = RandomForestClassifier(
            n_estimators=100,
            random_state=random_state,
            max_depth=10,
            min_samples_split=5,
            min_samples_leaf=2
        )
        
        self.model.fit(X_train_scaled, y_train)
        
        # Make predictions
        y_pred = self.model.predict(X_test_scaled)
        
        # Evaluate the model
        accuracy = accuracy_score(y_test, y_pred)
        print(f"\n=== Model Performance ===")
        print(f"Accuracy: {accuracy:.4f}")
        print(f"\nClassification Report:")
        print(classification_report(y_test, y_pred))
        
        # Feature importance
        feature_importance = pd.DataFrame({
            'feature': self.feature_names,
            'importance': self.model.feature_importances_
        }).sort_values('importance', ascending=False)
        
        print(f"\n=== Feature Importance ===")
        print(feature_importance)
        
        # Store test data for further evaluation
        self.X_test = X_test_scaled
        self.y_test = y_test
        self.y_pred = y_pred
        
        return accuracy
    
    def save_model(self, model_path='diabetes_model.pkl', scaler_path='diabetes_scaler.pkl'):
        """Save the trained model and scaler"""
        if self.model is None:
            print("No model to save!")
            return
        
        try:
            joblib.dump(self.model, model_path)
            joblib.dump(self.scaler, scaler_path)
            print(f"Model saved to {model_path}")
            print(f"Scaler saved to {scaler_path}")
        except Exception as e:
            print(f"Error saving model: {e}")
    
    def load_model(self, model_path='diabetes_model.pkl', scaler_path='diabetes_scaler.pkl'):
        """Load a pre-trained model and scaler"""
        try:
            self.model = joblib.load(model_path)
            self.scaler = joblib.load(scaler_path)
            print("Model and scaler loaded successfully!")
        except Exception as e:
            print(f"Error loading model: {e}")
    
    def predict_single(self, patient_data):
        """Predict diabetes for a single patient"""
        if self.model is None:
            print("No model loaded!")
            return None
        
        try:
            # Convert to DataFrame if it's a list or dict
            if isinstance(patient_data, (list, tuple)):
                patient_df = pd.DataFrame([patient_data], columns=self.feature_names)
            elif isinstance(patient_data, dict):
                patient_df = pd.DataFrame([patient_data])
            else:
                patient_df = patient_data
            
            # Scale the data
            patient_scaled = self.scaler.transform(patient_df)
            
            # Make prediction
            prediction = self.model.predict(patient_scaled)[0]
            probability = self.model.predict_proba(patient_scaled)[0]
            
            result = {
                'prediction': int(prediction),
                'probability_no_diabetes': float(probability[0]),
                'probability_diabetes': float(probability[1]),
                'risk_level': 'High' if probability[1] > 0.7 else 'Medium' if probability[1] > 0.3 else 'Low'
            }
            
            return result
            
        except Exception as e:
            print(f"Error making prediction: {e}")
            return None
    
    def predict_from_csv(self, csv_path):
        """Predict diabetes for multiple patients from CSV"""
        if self.model is None:
            print("No model loaded!")
            return None
        
        try:
            # Load the CSV data
            test_data = pd.read_csv(csv_path)
            
            # Ensure we have the right columns
            if not all(col in test_data.columns for col in self.feature_names):
                print(f"CSV must contain columns: {self.feature_names}")
                return None
            
            # Select only the required features
            X_test = test_data[self.feature_names]
            
            # Scale the data
            X_test_scaled = self.scaler.transform(X_test)
            
            # Make predictions
            predictions = self.model.predict(X_test_scaled)
            probabilities = self.model.predict_proba(X_test_scaled)
            
            # Create results DataFrame
            results = test_data.copy()
            results['Prediction'] = predictions
            results['Probability_No_Diabetes'] = probabilities[:, 0]
            results['Probability_Diabetes'] = probabilities[:, 1]
            results['Risk_Level'] = ['High' if p > 0.7 else 'Medium' if p > 0.3 else 'Low' 
                                   for p in probabilities[:, 1]]
            
            return results
            
        except Exception as e:
            print(f"Error predicting from CSV: {e}")
            return None

def main():
    """Main function to demonstrate the model"""
    # Initialize the model
    diabetes_model = DiabetesPredictionModel()
    
    # Load and explore data
    diabetes_model.load_data('diabetes_data.csv')
    diabetes_model.explore_data()
    
    # Train the model
    accuracy = diabetes_model.train_model()
    
    # Save the model
    diabetes_model.save_model()
    
    # Test with a sample prediction
    sample_patient = [6, 148, 72, 35, 0, 33.6, 0.627, 50]  # Example patient data
    print(f"\n=== Sample Prediction ===")
    result = diabetes_model.predict_single(sample_patient)
    if result:
        print(f"Patient data: {sample_patient}")
        print(f"Prediction: {'Diabetes' if result['prediction'] == 1 else 'No Diabetes'}")
        print(f"Diabetes probability: {result['probability_diabetes']:.4f}")
        print(f"Risk level: {result['risk_level']}")

if __name__ == "__main__":
    main()