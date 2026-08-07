import axios from 'axios';

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL || 'http://localhost:5036/api',
  headers: {
    'Content-Type': 'application/json',
  },
  timeout: 10000,
});

// Response interceptor for consistent response format and error handling
api.interceptors.response.use(
  (response) => response,
  (error) => {
    console.error('API Request Error:', error.response?.data || error.message);
    return Promise.reject(error);
  }
);

export default api;
