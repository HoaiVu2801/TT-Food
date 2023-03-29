import axios from 'axios'
const axiosClient = axios.create({
    baseURL: 'https://localhost:7054/api',
  });
export default axiosClient;