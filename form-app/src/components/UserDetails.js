import { useState } from "react";
import axios from "axios";

const API_URL = process.env.REACT_APP_API_URL;
const API_KEY = process.env.REACT_APP_API_KEY;


const UserDetails = () => {
  const [formData, setFormData] = useState({
    FirstName: "",
    CityName: "",
    YearOfJoining: "",
  });

  const [retrievedData, setRetrievedData] = useState(null);

  const currentYear = new Date().getFullYear();
  const minYear = currentYear - 5;

  // Handling input changes 
  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  // Validate YearOfJoining when the user finishes typing (onBlur)
  const validateYearOnBlur = () => {
    const year = Number(formData.YearOfJoining);
    if (year < minYear || year > currentYear) {
      alert(`Year should be between ${minYear} and ${currentYear}`);
      setFormData({ ...formData, YearOfJoining: "" }); 
    }
  };

  //Form validation before submitting
  const validateForm = () => {
    if (!formData.FirstName.trim()) {
      alert("First Name is required");
      return false;
    }
    if (!formData.CityName.trim()) {
      alert("City Name is required");
      return false;
    }
    if (!formData.YearOfJoining) {
      alert(`Year of Joining is required (Between ${minYear} and ${currentYear})`);
      return false;
    }
    return true;
  };

  // Handling Save
  const handleSave = async () => {
    if (!validateForm()) return;

    try {
      const response = await axios.post(
        `${API_URL}/saveData`,
        formData,
        { headers: { "x-api-key": API_KEY } }
      );
      alert("Data saved successfully!");
      console.log("Response:", response.data);
    } catch (error) {
      console.error("Error saving data:", error.response?.data || error.message);
      alert("Failed to save data!");
    }
  };

  // Handling Retrieve
  const handleRetrieve = async () => {
    try {
      const response = await axios.get(`${API_URL}/retrieveData`, {
        headers: { "x-api-key": API_KEY },
      });
      setRetrievedData(response.data);
    } catch (error) {
      console.error("Error retrieving data:", error.response?.data || error.message);
      alert("Failed to retrieve data!");
    }
  };

  return (
    <div className="flex items-center justify-center min-h-screen bg-yellow-100">
      <div className="bg-white p-10 rounded-lg shadow-lg text-center w-96 border border-yellow-300">
        <h1 className="text-2xl font-bold text-gray-700">User Details</h1>

        <div className="mt-5">
          <label className="block font-semibold text-gray-700">First Name:</label>
          <input
            type="text"
            name="FirstName"
            value={formData.FirstName}
            onChange={handleChange}
            className="w-full p-2 rounded border border-yellow-300 focus:outline-none focus:ring-2 focus:ring-yellow-400"
            required
          />
        </div>

        <div className="mt-3">
          <label className="block font-semibold text-gray-700">City Name:</label>
          <input
            type="text"
            name="CityName"
            value={formData.CityName}
            onChange={handleChange}
            className="w-full p-2 rounded border border-yellow-300 focus:outline-none focus:ring-2 focus:ring-yellow-400"
            required
          />
        </div>

        <div className="mt-3">
          <label className="block font-semibold text-gray-700">Year of Joining:</label>
          <input
            type="number"
            name="YearOfJoining"
            value={formData.YearOfJoining}
            onChange={handleChange} 
            onBlur={validateYearOnBlur}
            min={minYear}
            max={currentYear}
            className="w-full p-2 rounded border border-yellow-300 focus:outline-none focus:ring-2 focus:ring-yellow-400"
            required
          />
        </div>

        <div className="mt-5 flex justify-between">
          <button
            onClick={handleSave}
            className="bg-yellow-400 text-gray-800 px-5 py-2 rounded shadow-md hover:bg-yellow-500 transition"
          >
            Save
          </button>
          <button
            onClick={handleRetrieve}
            className="bg-yellow-400 text-gray-800 px-5 py-2 rounded shadow-md hover:bg-yellow-500 transition"
          >
            Retrieve
          </button>
        </div>

        {retrievedData && (
          <div className="mt-5 bg-yellow-50 p-3 rounded shadow border border-yellow-300">
            <h2 className="text-lg font-semibold text-gray-700">Retrieved Data:</h2>
            <p><strong>First Name:</strong> {retrievedData.firstName}</p>
            <p><strong>City Name:</strong> {retrievedData.cityName}</p>
            <p><strong>Year of Joining:</strong> {retrievedData.yearOfJoining}</p>
          </div>
        )}
      </div>
    </div>
  );
};

export default UserDetails;
