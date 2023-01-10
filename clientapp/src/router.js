import { createWebHistory, createRouter } from "vue-router";

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
  
export default router;