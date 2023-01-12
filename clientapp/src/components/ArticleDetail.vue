<template>
    <v-container>
      
    </v-container>
</template>

<script>
    import ArticlesDataService from "../services/ArticlesDataService";

    export default {


        name: "article-detail",

        data: () => ({
            Articles: null
        }),
        methods: {
            getArticles() {
              ArticlesDataService.getAll()
                .then(response => {
                    this.Articles = response.data;
                console.log(response.data);
                })
                .catch(e => {
                  console.log(e);
                });
            }
        },
        mounted() {
            this.message = '';
            this.getArticles();
        }
    }
</script>