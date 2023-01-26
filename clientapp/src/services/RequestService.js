import http from "../httpcommon";
import authHeader from "./AuthHeader";

class RequestService {
    getAll() {
        return http.get("/article/get");
    }

    get(id) {
        return http.get(`/article/get/${id}`);
    }

    create(data) {
        return http.post("/article/post", data, { headers: authHeader()});
    }

    update(data) {
        return http.put(`/article/put`, data, { headers: authHeader()});
    }

    delete(id) {
        return http.delete(`/article/delete/${id}`, { headers: authHeader()});
    }

    deleteAll() {
        return http.delete(`/article`, { headers: authHeader()});
    }

    findByTitle(title) {
        return http.get(`/article/${title}`);
    }

    registration(user) {
        return http.post('/account/registration', user);
    }

    login(user) {
        return http.post('/account/login', user);
    }

}

export default new RequestService();