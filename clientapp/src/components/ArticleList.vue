<template>
    <v-container>
        <!-- Создаем контейнер внутри которого и будут элементы компонента -->

        <v-row class="list__cafes-title">
            <!-- В это row выводим заголовок компонента -->
            <v-col>
                <h2 class="text-center text-h3 py-3">Blogs</h2>
            </v-col>
        </v-row>

        <v-row class="list__cafes-content">
            <v-col md="6" v-for="item in Articles" :key="item.id">
                <v-card>
                    <router-link :to="{ path: '/article/'+ item.id}">
                        <v-img height="500"
                               :src="item.previewImgSrc"></v-img> <!-- С помощью v-img добавляем изображение карточки -->
                    </router-link>
                        <v-card-title>
                            <!--<router-link :to="{ path: 'article',name: 'article-detail'}" class="dropdown-item">-->
                            <!-- Заголовок заведения -->
                            <h3 class="text-h6">{{ item.title }}</h3>
                       
                        </v-card-title>
                    
                    <v-card-text width="1000">
                        <!-- Описание заведения -->
                        <p class="text-body-1" v-html="item.text"></p>
                    </v-card-text>

                </v-card>
            </v-col>
        </v-row>

    </v-container>
</template>

<script>
    import ArticlesDataService from "../services/ArticlesDataService";

    export default {


        name: "article-list",

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
<style>
    .text-body-1, .text-h6 {
        background: #f4eddf; /* Цвет фона */
        padding: 10px; /* Поля вокруг текста */
        white-space: nowrap; /* Текст не переносится */
        overflow: hidden; /* Обрезаем всё за пределами блока */
        text-overflow: ellipsis;
    }
</style>