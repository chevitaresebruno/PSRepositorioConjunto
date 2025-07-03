from django.urls import path, register_converter, include
from rest_framework import routers
from .api_views import (
    UsuarioViewSet,
    CategoriaViewSet,
    TarefaViewSet,
)
router = routers.DefaultRouter()

router.register(r'usuario', UsuarioViewSet, basename='usuario')
router.register(r'categoria', CategoriaViewSet, basename='categoria')
router.register(r'tarefa', TarefaViewSet, basename='tarefa')

urlpatterns = [
    path('todoapp/', include(router.urls))
]
