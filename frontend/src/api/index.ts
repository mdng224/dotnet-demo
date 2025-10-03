import axios from "axios";
import type { AxiosInstance, InternalAxiosRequestConfig } from "axios";

const apiClient: AxiosInstance = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL ?? "http://localhost:3000",
  headers: { "Content-Type": "application/json" },
  withCredentials: true
});

// attach JWT if present
apiClient.interceptors.request.use((config: InternalAxiosRequestConfig) => {
  const token = localStorage.getItem("authToken");
  if (token) {
    config.headers = config.headers ?? {};
    // works across Axios v1 header types
    (config.headers as any).Authorization = `Bearer ${token}`;
  }
  return config;
});

export default apiClient;
