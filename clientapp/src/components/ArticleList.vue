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
            <v-col md="10" v-for="item in Articles" :key="item.id">
                <v-card>

                    <v-img height="500"
                           :src="item.previewImgSrc"></v-img> <!-- С помощью v-img добавляем изображение карточки -->

                    <v-card-title>
                        <router-link :to="{ path: 'article', query: { plan: 'private' }}, name: 'article-detail', params: { idElement: item.id }" class="dropdown-item">
                            <!-- Заголовок заведения -->
                            <h3 class="text-h4">{{ item.title }}</h3>
                        </router-link>
                    </v-card-title>

                    <v-card-text>
                        <!-- Описание заведения -->
                        <p class="text-body-1">{{ item.text }}</p>
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