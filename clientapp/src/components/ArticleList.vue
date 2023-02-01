<template>
    <v-container>
        <v-row class="">
           <v-col>
                <h2 class="text-center text-h3 py-3">Blogs</h2>
            </v-col>
        </v-row>

        <v-row class="">
            <v-col md="6" v-for="item in Articles" :key="item.id">
                <v-card>
                    <router-link :to="{ path: '/article/'+ item.id}">
                        <v-img class="d-flex justify-center mb-6 mt-10 mx-auto my-12" width="1000"
                               :src="item.previewImgSrc"></v-img>
                    </router-link>
                    <v-card-title>
                        
                        <h3 class="text-h6">{{ item.title }}</h3>
                        
                    </v-card-title>
                    
                    <v-card-text width="1000">
                        <div class="my-4 text-subtitle-1">
                            {{ item.author }}
                          </div>
                        <p class="text-body-1" v-html="item.text"></p>
                    </v-card-text>

                </v-card>
            </v-col>
        </v-row>

    </v-container>
</template>

<script>
    import RequestService from "../services/ArticleService";

    export default {


        name: "article-list",

        data: () => ({
            Articles: null
        }),
        methods: {
            getArticles() {
                RequestService.getAll()
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
<style>
    .text-body-1, .text-h6 {
        background: #f4eddf; 
        padding: 10px;
        white-space: nowrap; 
        overflow: hidden;
        text-overflow: ellipsis;
    }
</style>