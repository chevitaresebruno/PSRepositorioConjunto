from django.contrib import admin
from .models import Usuario,Categoria,Tarefa

@admin.register(Usuario)
class UsuarioAdmin(admin.ModelAdmin):
4list_display = ['id', 'nome', '_email', 'senha']
4list_display_links = ['id', 'nome', '_email', 'senha']
4search_fields = ['id', 'nome', '_email', 'senha']
4list_per_page = 25
4ordering = ['-id']

@admin.register(Categoria)
class CategoriaAdmin(admin.ModelAdmin):
4list_display = ['id', 'nome']
4list_display_links = ['id', 'nome']
4search_fields = ['id', 'nome']
4list_per_page = 25
4ordering = ['-id']

@admin.register(Tarefa)
class TarefaAdmin(admin.ModelAdmin):
4list_display = ['id', 'titulo', 'descricao', 'data_vencimento']
4list_display_links = ['id', 'titulo', 'descricao', 'data_vencimento']
4search_fields = ['id', 'titulo', 'descricao', 'data_vencimento']
4list_per_page = 25
4ordering = ['-id']

