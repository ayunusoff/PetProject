<template>
    <v-app-bar app
               color="red">
        <v-app-bar-title>
            <h3 class="text-h4 white--text">PetProject</h3>
        </v-app-bar-title>
        <router-link to="/#" class="navbar-brand">bezKoder</router-link>
        <router-link to="/article" class="nav-link">article</router-link>
        <router-link to="/article/post" class="nav-link">Add</router-link>
    </v-app-bar>
</template>
<script>
    export default {
        name: 'main-header',
    }
</script>