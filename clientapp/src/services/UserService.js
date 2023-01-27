import http from "@/httpcommon";

class UserService {
    getUserById(id) {
        http.get(`/account/${id}`).then().catch();
    }
}

export default new UserService();