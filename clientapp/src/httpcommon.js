import axios from "axios";
import router from "@/router"
import { useAuthStore } from "@/stores/auth.js";

console.log(typeof localStorage.getItem('token'));

 const http = axios.create({
  baseURL: "http://localhost:5000/"
});

http.defaults.headers.post['Content-Type'] = "application/json";
http.interceptors.request.use(
  (request) => {
    request.withCredentials = true;
    return request;
  });
http.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    let store = useAuthStore();
    if (error.response.status === 401) {
      store.authError = true;
      console.log(store.authError);
      console.log(error.response.status)
      router.push("/account/signin");
    }
    return Promise.reject(error);
  });

export default http