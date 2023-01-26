import { createWebHistory, createRouter } from "vue-router";
import ArticleList from '@/components/ArticleList'
import ArticleDetail from '@/components/ArticleDetail'
import ArticlePost from '@/components/ArticlePost'
import Register from '@/components/Register'
import Login from '@/components/Login'

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
        path: "/article/create",
        name: "article-create",
        component: ArticlePost
    },
    {
        path: "/account/signup",
        name: "account-signup",
        component: Register
    },
    {
        path: "/account/signin",
        name: "account-signin",
        component: Login
    },
];



const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;