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
        <router-link to="/article/post" class="nav-link">
            <v-btn>
                Add article
            </v-btn>
        </router-link>
        <router-link to="/account/reg" class="nav-link">
            <v-btn>
                Sign in
            </v-btn>
        </router-link>
    </v-app-bar>
</template>
<script>
    export default {
        name: 'main-header',
    }
</script>
<style>
    .nav-link {
        color: burlywood;
        text-decoration: none;
    }
</style>