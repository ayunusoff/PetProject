<template>
    <v-card>
        <v-toolbar
          flat
          color="#FAEBD7"
          dark
        >
          <v-toolbar-title>Submit a post</v-toolbar-title>
        </v-toolbar>
    
        <v-card-text>

            <v-text-field
            label="Image"
            v-model="form.previewImgSrc"
          ></v-text-field>
          <v-text-field
            label="Title"
            v-model="form.title"
          ></v-text-field>
    
          <v-textarea
            label="Text"
            v-model="form.text"
          ></v-textarea>
    
          <v-divider class="my-2"></v-divider>
    
          <v-item-group multiple>
            <v-subheader>Tags</v-subheader>
            <v-item
              v-for="n in 8"
              :key="n"
              v-slot="{ active, toggle }"
            >
              <v-chip
                active-class="purple--text"
                :input-value="active"
                @click="toggle"
              >
                Tag {{ n }}
              </v-chip>
            </v-item>
          </v-item-group>
        </v-card-text>

        <v-divider></v-divider>
    
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="success"
            depressed
            @click="submitForm"
          >
            Post
          </v-btn>
        </v-card-actions>
      </v-card>
</template>
  
<script>
    import ArticleService from '@/services/ArticleService';
    
    export default {
        name: 'article-create',
        data() {
            return {
                form: {
                    title: '',
                    text: '',
                    previewImgSrc: '',
                    author: ''
                },
                titleRules: [
                    v => !!v || 'Name is required',
                    v => v.length <= 50 || 'Name must be less than 50 characters',
                ],
                textRules: [
                    v => !!v || 'Name is required',
                    v => v.length <= 500 || 'Name must be less than 500 characters',
                ],
            }
        },
        mounted() {
            this.form.author = JSON.parse(localStorage.getItem('user'));
            console.log(this.form.author);
        },
        methods: {
            submitForm() {
                ArticleService.create(this.form);
            }
        }
    }
  </script>
  
  <style>
  .submit-form {
    max-width: 300px;
    margin: auto;
  }
  </style>