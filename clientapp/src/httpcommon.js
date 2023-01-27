import axios from "axios";
axios.defaults.headers.common['Authorization'] = `Bearer ${localStorage.getItem('token')}`;
console.log(typeof localStorage.getItem('token'));

 const http = axios.create({
  baseURL: "https://localhost:7208/"
});

http.defaults.headers.post['Content-Type'] = "application/json";

export default http