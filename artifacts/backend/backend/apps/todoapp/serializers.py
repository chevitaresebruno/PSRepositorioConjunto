from rest_framework import serializers
from .models import (
    Usuario,
    Categoria,
    Tarefa,
)

class UsuarioWriteSerializer(serializers.ModelSerializer):
    class Meta:
        model = Usuario
        exclude = ("polymorphic_ctype",)

class UsuarioReadSerializer(serializers.ModelSerializer):
    class Meta:
        depth = 1
        model = Usuario
        exclude = ("polymorphic_ctype",)


class CategoriaWriteSerializer(serializers.ModelSerializer):
    class Meta:
        model = Categoria
        exclude = ("polymorphic_ctype",)

class CategoriaReadSerializer(serializers.ModelSerializer):
    class Meta:
        depth = 1
        model = Categoria
        exclude = ("polymorphic_ctype",)


class TarefaWriteSerializer(serializers.ModelSerializer):
    class Meta:
        model = Tarefa
        exclude = ("polymorphic_ctype",)

class TarefaReadSerializer(serializers.ModelSerializer):
    class Meta:
        depth = 1
        model = Tarefa
        exclude = ("polymorphic_ctype",)

