import { createWebHistory, createRouter } from "vue-router";
import ArticleList from '@/components/ArticleList'
import ArticleDetail from '@/components/ArticleDetail'
import ArticlePost from '@/components/ArticlePost'

const routes = [
    {
        path: "/",
        alias: "/article",
        name: "article-list",
        component: ArticleList
    },
    {
        path: "/article/:id",
        name: "article-detail",
        component: ArticleDetail
    },
    {
        path: "/article/post",
        name: "article-post",
        component: ArticlePost
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;