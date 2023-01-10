<template>
    <div class="submit-form">
      <div v-if="!submitted">
        <div class="form-group">
          <label for="title">Title</label>
          <input
            type="text"
            class="form-control"
            id="title"
            required
            v-model="article.title"
            name="title"
          />
        </div>
  
        <div class="form-group">
          <label for="Text">Text</label>
          <input
            class="form-control"
            id="description"
            required
            v-model="article.text"
            name="text"
          />
        </div>
        
        <div class="form-group">
            <label for="previewImgSrc">imgSrc</label>
            <input
              class="form-control"
              id="description"
              required
              v-model="article.previewImgSrc"
              name="previewImgSrc"
            />
        </div>
          
        <button @click="saveArticle" class="btn btn-success">Submit</button>
      </div>
  
      <div v-else>
        <h4>You submitted successfully!</h4>
        <button class="btn btn-success" @click="newArticle">Add</button>
      </div>
    </div>
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
          description: this.article.text
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