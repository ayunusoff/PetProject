import { createWebHistory, createRouter } from "vue-router";
import ArticleDetail from '@/components/ArticleDetail'
import ArticleList from '@/components/ArticleList'
import UserProfile from '@/components/UserProfile'
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
        component: ArticlePost,
        beforeEnter: (to) => {
            if (!localStorage.getItem('user') && to.name !== 'account-signin') {
                
                return { name: 'account-signin' }
            }
        }
    },
    {
        path: "/account/signup",
        name: "account-signup",
        component: Register
    },
    {
        path: "/account/signin",
        name: "account-signin",
        component: Login,
        beforeEnter: (to) => {
            if (localStorage.getItem('user') && to.name == 'account-signin') {
                
                return { name: 'user-profile' }
            }
        }
    },
    {
        path: "/account/:id",
        name: "user-profile",
        component: UserProfile,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;