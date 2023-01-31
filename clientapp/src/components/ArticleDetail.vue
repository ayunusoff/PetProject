<template>
    <v-card class="mx-auto my-12" elevation="24" max-width="80%">
        <v-img :src="this.Article.previewImgSrc"></v-img> <v-card-title>
            {{ this.Article.title }}
        </v-card-title>
        <v-card-text>
            {{ this.Article.text }}
        </v-card-text>
       
        <v-card-actions>
            <v-btn
            class="ma-2"
            text
            icon
            color="blue lighten-2"
            >
                <v-icon>mdi-thumb-up</v-icon>
            </v-btn>
  
            <v-btn
            class="ma-2"
            text
            icon
            color="red lighten-2"
            >
                <v-icon>mdi-thumb-down</v-icon>
            </v-btn>
            
            <v-btn
            class="ma-2"
            text
            icon
            color="red lighten-2"
            >
                {{ this.Article.viewCount }}
            </v-btn>
            
        </v-card-actions>
    </v-card>
</template>

<script>
import articleService from "../services/ArticleService";

export default {

    name: "article-detail",

    data: () => ({
        noImage: '../public/favicon.ico',
        Article: {
            previewImgSrc: '',
            title: '',
            text: '',
            dateAdd: '',
            author: '',
            viewCount: '',
        },
        viewCounter: 0
    }),
    created() {
        
    },
    methods: {
        img() {
            if (this.Article.previewImgSrc == null)
            this.previewImgSrc = this.noImage;
            console.log(this.$route.id);
            this.getArticle();
        },
        view() {
            articleService.viewCounter(this.$route.params.id);
        },
        getArticle() {
            const id = this.$route.params.id;
            console.log(id);
            articleService.get(id)
                .then((response) => {
                    this.Article = response.data;
                    this.viewCounter = this.Article.viewCount; 
                    console.log(this.viewCounter);
                })
                .catch((e) => {
                    this.errors.push(e);
                });
        }
    },
        
    mounted() {
        this.getArticle();
        this.view();
        this.viewCounter += 1;
    }
}
</script>