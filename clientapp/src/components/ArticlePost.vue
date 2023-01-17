<template>
    <v-form v-model="valid">
        <v-container>
            <v-row>
                <v-col cols="12"
                       md="4">
                    <v-text-field v-model="article.title"
                                  :rules="nameRules"
                                  :counter="20"
                                  label="title"
                                  required></v-text-field>
                </v-col>

                <v-col cols="12"
                       md="4">
                    <v-text-field v-model="article.text"
                                  :rules="nameRules"
                                  :counter="500"
                                  label="text"
                                  required></v-text-field>
                </v-col>

                <v-col cols="12"
                       md="4">
                    <v-text-field v-model="article.previewImgSrc"
                                  :rules="emailRules"
                                  label="previewImgSrc"
                                  required></v-text-field>
                </v-col>
            </v-row>
        </v-container>
        <v-btn type="submit" class="mr-4"
               @click="submit">
            submit
        </v-btn>
    </v-form>
</template>
  
  <script>
  import ArticlesDataService from "../services/ArticlesDataService";
  
  export default {
    name: "article-post",
    data() {
      return {
        article: {
          title: "",
          text: "",
          previewImgSrc: ""
        },
        submitted: false
      };
    },
    methods: {
      saveArticle() {
        var data = {
            title: this.article.title,
            description: this.article.text,
            previewImgSrc: this.article.previewImgSrc
        };
  
        ArticlesDataService.create(data)
          .then(response => {
            console.log(response.data);
            this.submitted = true;
          })
          .catch(e => {
            console.log(e);
          });
      },
      
      newArticle() {
        this.submitted = false;
        this.article = {};
      }
    }
  };
  </script>
  
  <style>
  .submit-form {
    max-width: 300px;
    margin: auto;
  }
  </style>