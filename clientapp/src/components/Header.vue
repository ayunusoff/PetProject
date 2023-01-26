<template>
    <v-app-bar app
               color="red">
        <v-app-bar-title>
            <h3 class="text-h4 white--text">PetProject</h3>
        </v-app-bar-title>
        <router-link to="/#" class="nav-link">
            <v-btn>
                Home
            </v-btn>
        </router-link>
        <router-link to="/article" class="nav-link">
            <v-btn>
                articles
            </v-btn>
        </router-link>
        <router-link to="/article/create" class="nav-link">
            <v-btn>
                Add article
            </v-btn>
        </router-link>
        <div v-if="this.useStore.getAuthState">
            <router-link to="/account" class="nav-link">
                <v-btn color="white">
                    {{ this.useStore.getUser.nickname }}
                </v-btn>
            </router-link>
            <router-link to="/article" @click="logout" class="nav-link">
                <v-btn>
                    Logout
                </v-btn>
            </router-link>
        </div>
        <div v-else>
            <router-link to="/account/signin" class="nav-link">
                <v-btn>
                    Sign in
                </v-btn>
            </router-link>
        </div>
    </v-app-bar>
</template>
<script>
    import {useAuthStore} from '../stores/auth.js'
    import {storeToRefs} from 'pinia'

    export default {
        name: 'main-header',
        setup() {
            let useStore = useAuthStore();
            let {user, token, loggedIn} = storeToRefs(useStore)
            return {
                useStore, 
                user,
                token,
                loggedIn
            }
        },
        methods: {
            async logout() {
                await this.useStore.logout();
            }
        }
    }
</script>
<style>
    .nav-link {
        color: burlywood;
        text-decoration: none;
    }
</style>