/*import { createWebHistory, createRouter } from "vue-router";

const routes =  [
  {
    path: "/",
    alias: "/article",
    name: "article-list",
    component: () => import("./components/ArticleList")
  },
  {
    path: "/article/:id",
    name: "articles-details",
    component: () => import("./components/Articles")
  },
  {
    path: "/article/post",
    name: "article-post",
    component: () => import("./components/ArticlePost")
  }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
  });
  
export default router;*/
import { createWebHistory, createRouter } from "vue-router";
import ArticleList from '@/components/ArticleList'
import ArticleDetail from '@/components/ArticleDetail'

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
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;