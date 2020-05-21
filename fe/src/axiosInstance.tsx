import axios from 'axios';
import { useHistory } from 'react-router';

export const axiosInstance = axios.create({
  baseURL: 'https://localhost:44311/api/',
  timeout: 60000,
  headers: {
  'Content-Type': 'application/json',
  'Accept':'application/json'}
});
axiosInstance.interceptors.response.use(undefined, function (error) {
  //alert(error.response.status);
  if(error.response.status === 401) {
    window.sessionStorage.clear();
    window.location.href="/";
    return Promise.reject(error);
  }
  if(error.response.status === 403) {
    window.location.href="/dashboard"
    return Promise.reject(error);
  }
  
  
});