<template>
    <v-toolbar app
               color="red">
        
        <v-app-bar-nav-icon @click.stop="drawer = !drawer" class="d-flex d-sm-none"></v-app-bar-nav-icon>
        <v-toolbar-title>PetProject</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-tabs align-with-title class="d-none d-sm-flex">
            <v-tabs-slider color="red"></v-tabs-slider>
            <v-tab>
            <router-link to="/#" class="nav-link">
                <v-btn>
                    Home
                </v-btn>
            </router-link>
            </v-tab>
            <v-tab>
            <router-link to="/article" class="nav-link">
                <v-btn>
                    articles
                </v-btn>
            </router-link>
            </v-tab>
            <v-tab>
            <router-link to="/article/create" class="nav-link">
                <v-btn>
                    Add article
                </v-btn>
            </router-link>
            </v-tab>
        
            <div v-if="this.useStore.user">
                <v-tab>
                <router-link :to="{ path: '/account/'+ this.useStore.getUser}" class="nav-link">
                    <v-btn color="white">
                        {{ this.useStore.getUser }}
                    </v-btn>
                </router-link>
                </v-tab>
                <v-tab>
                <router-link to="" @click="logout" class="nav-link">
                    <v-btn>
                        Logout
                    </v-btn>
                </router-link>
                </v-tab>
            </div>
        
            <div v-else>
                <v-tab>
                <router-link to="/account/signin" class="nav-link">
                    <v-btn>
                        Sign in
                    </v-btn>
                </router-link>
                </v-tab>
            </div>
        </v-tabs>
    </v-toolbar>
    <v-navigation-drawer
        v-model="drawer"
        absolute
        temporary
    >
        <v-list
            nav
            dense
        >
            <v-list-item-group
                v-model="group"
                active-class="deep-purple--text text--accent-4"
            >
                <v-list-item>
                    <v-list-item-title>
                        <router-link to="/article" class="nav-link">
                            <v-btn>
                                articles
                            </v-btn>
                        </router-link>
                    </v-list-item-title>
                </v-list-item>
                <v-list-item>
                    <v-list-item-title>
                        <router-link to="/article/create" class="nav-link">
                            <v-btn>
                                Add article
                            </v-btn>
                        </router-link>
                    </v-list-item-title>
                </v-list-item>
                <v-list-item>
                    <v-list-item-title v-if="this.useStore.user">
                        <router-link :to="{ path: '/account/'+ this.useStore.getUser}" class="nav-link">
                            <v-btn color="white">
                                {{ this.useStore.getUser }}
                            </v-btn>
                        </router-link>
                        <router-link to="" @click="logout" class="nav-link">
                            <v-btn>
                                Logout
                            </v-btn>
                        </router-link>
                    </v-list-item-title>
                    <v-list-item-title v-else>
                        <router-link to="/account/signin" class="nav-link">
                            <v-btn>
                                Sign in
                            </v-btn>
                        </router-link>
                    </v-list-item-title>
                </v-list-item>
            </v-list-item-group>
        </v-list>
    </v-navigation-drawer>
</template>
<script>
    import {useAuthStore} from '../stores/auth.js'

    export default {
        name: 'main-header',
        setup() {
            let useStore = useAuthStore();
           
            return {
                useStore
            }
        },
        data: () => ({
            drawer: false,
            group: null,
        }),
        watch: {
            group () {
            this.drawer = false
            },
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