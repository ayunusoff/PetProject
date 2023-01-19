<template>
    <v-form v-model="valid" v-on:submit.prevent="submitForm">
        <v-container>
            <v-row>
                <v-col cols="12" md="4">
                    <v-text-field id="title"
                                  v-model="form.title"
                                  color="green"
                                  :counter="50"
                                  label="Title"
                                  :rules="titleRules"
                                  required>
                    </v-text-field>
                </v-col>
                <v-col cols="12" md="10">
                    <v-text-field id="previewImgSrc"
                                  v-model="form.previewImgSrc"
                                  color="red"
                                  label="Preview Image for your blog"
                                  required>
                    </v-text-field>
                </v-col>
            </v-row>
            <v-row>
                <v-col cols="12"
                       sm="6"
                       class="py-2">
                    <p>Exclusive</p>

                    <v-btn-toggle v-model="toggle_exclusive">
                        <v-btn>
                            <v-icon>mdi-format-align-left</v-icon>
                        </v-btn>

                        <v-btn>
                            <v-icon>mdi-format-align-center</v-icon>
                        </v-btn>

                        <v-btn>
                            <v-icon>mdi-format-align-right</v-icon>
                        </v-btn>

                        <v-btn>
                            <v-icon>mdi-format-align-justify</v-icon>
                        </v-btn>
                    </v-btn-toggle>
                </v-col>

                <v-col cols="12"
                       sm="6"
                       class="py-2">
                    <p>Multiple</p>

                    <v-btn-toggle v-model="toggle_multiple"
                                  dense
                                  background-color="primary"
                                  dark
                                  multiple>
                        <v-btn>
                            <v-icon>mdi-format-bold</v-icon>
                        </v-btn>

                        <v-btn>
                            <v-icon>mdi-format-italic</v-icon>
                        </v-btn>

                        <v-btn>
                            <v-icon>mdi-format-underline</v-icon>
                        </v-btn>

                        <v-btn>
                            <v-icon>mdi-format-color-fill</v-icon>
                        </v-btn>
                    </v-btn-toggle>
                </v-col>

                <v-col cols="12"
                       sm="6"
                       class="py-2">
                    <p>No Options Selected</p>

                    <v-btn-toggle v-model="toggle_none">
                        <v-btn>
                            <v-icon>mdi-format-align-left</v-icon>
                        </v-btn>

                        <v-btn>
                            <v-icon>mdi-format-align-center</v-icon>
                        </v-btn>
                        <v-btn>
                            <v-icon>mdi-format-align-right</v-icon>
                        </v-btn>

                        <v-btn>
                            <v-icon>mdi-format-align-justify</v-icon>
                        </v-btn>
                    </v-btn-toggle>
                </v-col>

                <v-col cols="12"
                       sm="6"
                       class="py-2">
                    <p>Mandatory</p>

                    <v-btn-toggle v-model="toggle_one"
                                  shaped
                                  mandatory>
                        <v-btn>
                            <v-icon>mdi-format-align-left</v-icon>
                        </v-btn>

                        <v-btn>
                            <v-icon>mdi-format-align-center</v-icon>
                        </v-btn>

                        <v-btn>
                            <v-icon>mdi-format-align-right</v-icon>
                        </v-btn>

                        <v-btn>
                            <v-icon>mdi-format-align-justify</v-icon>
                        </v-btn>
                    </v-btn-toggle>
                </v-col>

                <v-col cols="12"
                       class="py-2">
                    <p>Text Options</p>

                    <v-btn-toggle v-model="text"
                                  tile
                                  color="deep-purple accent-3"
                                  group>
                        <v-btn value="left">
                            Left
                        </v-btn>

                        <v-btn value="center">
                            Center
                        </v-btn>

                        <v-btn value="right">
                            Right
                        </v-btn>

                        <v-btn value="justify">
                            Justify
                        </v-btn>
                    </v-btn-toggle>
                </v-col>

                <v-col cols="12"
                       class="py-2">
                    <p>Text &amp; Icon Options</p>

                    <v-btn-toggle v-model="icon"
                                  borderless>
                        <v-btn value="left">
                            <span class="hidden-sm-and-down">Left</span>

                            <v-icon right>
                                mdi-format-align-left
                            </v-icon>
                        </v-btn>

                        <v-btn value="center">
                            <span class="hidden-sm-and-down">Center</span>

                            <v-icon right>
                                mdi-format-align-center
                            </v-icon>
                        </v-btn>

                        <v-btn value="right">
                            <span class="hidden-sm-and-down">Right</span>

                            <v-icon right>
                                mdi-format-align-right
                            </v-icon>
                        </v-btn>

                        <v-btn value="justify">
                            <span class="hidden-sm-and-down">Justify</span>

                            <v-icon right>
                                mdi-format-align-justify
                            </v-icon>
                        </v-btn>
                    </v-btn-toggle>
                </v-col>
            </v-row>
            <v-row>

                <v-col cols="12" md="10">
                    <v-textarea id="text"
                                background-color="amber lighten-4"
                                color="orange orange-darken-4"
                                label="Text for your blog"
                                :rules="textRules"
                                v-model="form.text"
                                :counter="10000">
                    </v-textarea>
                </v-col>
            </v-row>
            <v-row>
                <v-btn color="primary"
                       text
                       @click="submitForm">
                    Submit
                </v-btn>
            </v-row>
        </v-container>
        
    </v-form>
</template>
  
  <script>
      import axios from 'axios';
      /*/<v-col cols="12"
      md = "4" >
          <v-text-field
              v-model="form.text"
              label="Text"
              required>
          </v-text-field>
                </v - col >*/
      export default {
          name: 'article-post',
          data() {
              return {
                  form: {
                      title: '',
                      text: '',
                      previewImgSrc: '',
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
          methods: {
              submitForm() {
                  axios.post('/article/post', this.form)
                      .then((res) => {
                          console.log(res);
                      })
                      .catch((error) => {
                          console.log(error);
                      }).finally(() => {
                          //Perform action in always
                      });
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