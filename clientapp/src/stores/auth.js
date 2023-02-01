import { defineStore } from 'pinia';
import AuthService from '@/services/AuthService'
import router from "@/router";

const useAuthStore = defineStore('auth', {
    state: () => {
        return {
            user: localStorage.getItem("user") || null,
            isLogged: false,
            authError: false,
        }
    },
    getters: {
        getUser:
            (state) => {
                state.user = JSON.parse(localStorage.getItem('user'));
                return state.user;
            },
        setUser: (state) => localStorage.setItem('user', JSON.stringify(state.user))
    },
    actions: {
        async login(data) {
            AuthService.login(data)
                .then((res) => {
                    this.isLogged = true;
                    this.user = res.data;
                    this.authError = false;
                    localStorage.setItem('user', JSON.stringify(res.data));
                    console.log(this.user);
                    console.log(res.data.user)
                })
                .catch((res) => {
                    console.log(res);
                });
                
                router.push('/article');
        },
        async logout() {
            this.user = null;
            localStorage.removeItem('user');
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