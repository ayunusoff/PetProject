import { defineStore } from 'pinia';
import AuthService from '@/services/AuthService'
import router from "@/router";

const useAuthStore = defineStore('auth', {
    state: () => {
        return {
            token: localStorage.getItem("token") || null,
            user: localStorage.getItem("user") || null,
        }
    },
    getters: {
        getToken: (state) => state.token,
        getUser: (state) => JSON.parse(state.user),
        getAuthState: (state) => !!state.user,
    },
    actions: {
        login(data) {
            AuthService.login(data)
                .then((res) => {
                    localStorage.setItem('user', JSON.stringify(res.data.user));
                    localStorage.setItem('token', res.data.token.jwt);
                })
                .catch((res) => {
                    console.log(res);
                });
                
                router.push('/article');
        },
        async logout() {
            this.user = null;
            this.token = null;
            localStorage.removeItem('user');
            localStorage.removeItem('token')    
        },
        async registration(data) {
            AuthService.registration(data)
                .then((res) => {
                    console.log(res);
                })
                .catch((error) => {
                    console.log(error);
                });

            router.push("/account/signin");
        },
    },
})

export {useAuthStore}