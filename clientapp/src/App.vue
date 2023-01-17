<template>
    <v-app>
        <Header></Header>
        <v-main>
            <router-view></router-view>    
        </v-main>
    </v-app>
    <button class="badge badge-danger mr-2">
        Delete
    </button>
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
