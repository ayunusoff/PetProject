import http from '@/httpcommon'

class AuthService {
    registration(user) {
        return http.post('/account/registration', user);
    }

    login(user) {
        return http.post('/account/login', user);
    }
}

export default new AuthService();