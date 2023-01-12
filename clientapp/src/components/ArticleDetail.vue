<template>
    <v-container>
        <v-card>

            <v-img height="500"
                   :src="Article.previewImgSrc">
            </v-img>

            <v-card-title>
                <h3 class="text-h4">{{ Article.title }}</h3>
            </v-card-title>

            <v-card-text>
                <p class="text-body-1">{{ Article.text }}</p>
            </v-card-text>
        </v-card>
    </v-container>
</template>

<script>
    import ArticlesDataService from "../services/ArticlesDataService";

    export default {

        props: ["idElement"],
        name: "article-detail",

        data: () => ({
            Article: null
        }),
        methods: {
            getArticles() {
                ArticlesDataService.get(props.idElement)
                .then(response => {
                    this.Article = response.data;
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