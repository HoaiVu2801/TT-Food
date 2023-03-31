import axios from 'axios'
const axiosClient = axios.create({
  // baseURL: 'https://localhost:7054/api',
  baseURL: 'http://192.168.1.86:8082/api',
  });
export default axiosClient;