import http from "../httpcommon";
import router from "@/router";

class ArticleService {
    getAll() {
        return http.get("/article/get");
    }

    get(id) {
        return http.get(`/article/get/${id}`);
    }

    create(data) {
        return http.post("/article/post", data)
            .then((res) => {
                router.push(`/article/${res.data}`)
            })
        ;
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
}

export default new ArticleService();