<template>
    <v-app>
        <Header></Header>
        <v-main>
            <router-view></router-view>    
        </v-main>
    </v-app>
</template>

<script>
    import Header from '@/components/Header.vue';
    export default {
        name: 'App',
        components: {
            Header,
        }
    }
</script>
<style>
    .v-main {
        background-color: #FAEBD7;
    }
</style>
