import http from "../httpcommon";

class ArticlesDataService {
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
    return http.get(`/article?title=${title}`);
  }
}

export default new ArticlesDataService();