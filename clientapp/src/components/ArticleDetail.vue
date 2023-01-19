<template>
    <div v-html="Article.text"></div>
    <div v-html="inner"></div>
</template>

<script>
    //import ArticlesDataService from "../services/ArticlesDataService";
    import axios from 'axios'
    export default {

        name: "article-detail",

        data: () => ({
            noImage: '../public/favicon.ico',
            Article: null,
            inner: `<img height="50" : src="https://play-lh.googleusercontent.com/V_P-I-UENK93ahkQgOWel8X8yFxjhOOfMAZjxXrqp311Gm_RBtlDXHLQhwFZN8n4aIQ"><img>`,
        }),
        created() {
            const id = this.$route.params.id;
            axios
                .get(`/article/get/${id}`)
                .then((response) => {
                    // JSON responses are automatically parsed.
                    this.Article = response.data;
                    console.log(this.Article);
                })
                .catch((e) => {
                    this.errors.push(e);
                });
        },
        /*methods: {
            getArticle() {
                axios.get('article/get/' + this.$route.params.id).then((result) => {
                    this.Article = result.data;
                    console.log(this.Article);

                })
            },

            
            getArticles() {
                ArticlesDataService.get(this.$route.id)
                .then(response => {
                    this.Article = response.data.previewImgSrc;
                console.log(response.data);
                })
                .catch(e => {
                  console.log(e);
                });
        //    },*/
        //mounted() {
        //    if (this.Article.previewImgSrc == null)
        //        this.previewImgSrc = this.noImage;
        //    console.log(this.$route.id);
        //    this.getArticle();
        //}
    }
</script>