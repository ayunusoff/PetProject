import { defineStore } from 'pinia';
import axios from 'axios';
import RequestService from '@/services/RequestService'
import router from "@/router";

const useAuthStore = defineStore('user', {
    state: () => {
        return {
            token: localStorage.getItem("token") || null,
            user: localStorage.getItem("user") || null,
            counter: 1000,
        }
    },
    getters: {
        getToken: (state) => state.token,
        getUser: (state) => JSON.parse(state.user),
    },
    actions: {
        async login(data) {
            RequestService.login(data)
                .then((res) => {
                    console.log(res)
                    console.log(data)
                    localStorage.setItem('user', JSON.stringify(data));
                    localStorage.setItem('token', JSON.stringify(res.data.jwt));
                })
                .catch((res) => {
                    console.log(res);
                });
            
            
            router.push("/article");
        },
        async logout() {
            this.user = null;
            this.token = null;
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
            router.push("/account/login");
        },
    },
})
export {useAuthStore}