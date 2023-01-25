import http from "../httpcommon";

class RequestService {
    getAll() {
        return http.get("/article/get");
    }

    get(id) {
        return http.get(`/article/get/${id}`);
    }

    create(data) {
        return http.post("/article/post", data);
    }

    update(data) {
        return http.put(`/article/put`, data);
    }

    delete(id) {
        return http.delete(`/article/delete/${id}`);
    }

    deleteAll() {
        return http.delete(`/article`);
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