import { createApp } from 'vue'
import { createPinia } from 'pinia';
import App from './App.vue'
import vuetify from './plugins/vuetify'
import { loadFonts } from './plugins/webfontloader'
import router from './router'
import axios from 'axios'
import VueAxios from 'vue-axios'

loadFonts()

createApp(App)
    .use(createPinia())
    .use(VueAxios, axios)
    .use(vuetify)
    .use(router)
    .mount('#app')
