<template>
    <div class="d-flex justify-center">
        <v-form class="reg-form" align="center">
            <v-container fluid style=" width: 100%" align="center">
                <v-row>
                    <v-col align="center" color="red" width="100px" height="100px">

                        <v-avatar size="200" color="teal">
                            <img contain
                                 :src="form.imgSrc"
                                 height="500"
                                 size="250"
                                 alt="">
                        </v-avatar>
                    </v-col>

                </v-row>
                <v-row class="d-flex justify-center mb-6">
                    <v-col md="6" align="center">
                        <v-text-field id="login"
                                      v-model="form.imgSrc"
                                      color="green"
                                      :counter="50"
                                      max-width="100px"
                                      label="User image src"
                                      :rules="loginRules"
                                      required>

                        </v-text-field>
                    </v-col>
                </v-row>
                <v-row class="d-flex justify-center mb-6">
                    <v-col md="6">
                        <v-text-field id="login"
                                      v-model="form.login"
                                      color="green"
                                      :counter="50"
                                      label="login"
                                      :rules="loginRules"
                                      required>
                        </v-text-field>
                    </v-col>
                </v-row>
                <v-row class="d-flex justify-center mb-6">
                    <v-col md="6">
                        <v-text-field id="email"
                                      v-model="form.email"
                                      color="green"
                                      :counter="50"
                                      label="email"
                                      :rules="loginRules"
                                      required>
                        </v-text-field>
                    </v-col>
                </v-row>
                <v-row class="d-flex justify-center mb-6">
                    <v-col md="6">
                        <v-text-field id="password"
                                      v-model="form.password"
                                      color="green"
                                      :counter="50"
                                      label="password"
                                      :rules="loginRules"
                                      required>
                        </v-text-field>
                    </v-col>
                </v-row>

                <v-btn>Sign up</v-btn>
            </v-container>
        </v-form>
    </div>
</template>
<script>
    export default {
        name: 'account-reg',
        data() {
            return {
                form: {
                    login: '',
                    email: '',
                    password: '',
                    imgSrc: '',
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
    }
</script>
<style>
    #login {
        width: 100px;
    }
    .reg-form {
        box-shadow: 12px 12px 2px 1px rgba(0, 0, 255, .2);
        width: 60%;
        position: center;
    }
</style>