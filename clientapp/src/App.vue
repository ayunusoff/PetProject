<template>
  <v-app>
    <v-app-bar
      app
      color="red"
    >
    <v-app-bar-title>
      <h3 class="text-h4 white--text">PetProject</h3>
    </v-app-bar-title>
    <router-link to="/" class="navbar-brand">bezKoder</router-link>
    <router-link to="/article" class="nav-link">Tutorials</router-link>
    <router-link to="/add" class="nav-link">Add</router-link>
    </v-app-bar>
  </v-app>
</template>

<script>
export default {
  name: 'App',
}
</script>
