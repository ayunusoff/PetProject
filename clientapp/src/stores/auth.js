import { defineStore } from 'pinia';
import axios from 'axios';
import RequestService from '@/services/RequestService'
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
            RequestService.login(data)
                .then((res) => {
                    console.log(res);
                    console.log(data);
                    this.loggedIn = true;
                    console.log(this.loggedIn);
                    console.log(res.data.jwt);
                    localStorage.setItem('user', JSON.stringify(data));
                    localStorage.setItem('token', res.data.jwt);
                })
                .catch((res) => {
                    console.log(res);
                });
        },
        async logout() {
            this.user = null;
            this.token = null;
            this.loggedIn = false;
            localStorage.removeItem('user');
            localStorage.removeItem('token')    
        },
        async registration(data) {
            axios.post('/account/registration', data)
                .then((res) => {
                    console.log(res);
                })
                .catch((error) => {
                    console.log(error);
                }).finally(() => {
                });
            router.push("/account/signin");
        },
    },
})
export {useAuthStore}