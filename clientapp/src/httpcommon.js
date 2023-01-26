import axios from "axios";
axios.defaults.headers.common['Authorization'] = `Bearer ${localStorage.getItem('token')}`;
console.log(typeof localStorage.getItem('token'));
export default axios.create({
  baseURL: "https://localhost:7208/",
  headers: {
    "Content-type": "application/json"
  }
});