from django.db import models
from django.utils.translation import gettext_lazy as _
from polymorphic.models import PolymorphicModel

class Prioridade(models.TextChoices):
    """"""
    BAIXA = 'BAIXA', _('Baixa')
    MEDIA = 'MEDIA', _('Media')
    ALTA = 'ALTA', _('Alta')

class Status(models.TextChoices):
    """"""
    PENDENTE = 'PENDENTE', _('Pendente')
    ANDAMENTO = 'ANDAMENTO', _('Andamento')
    CONCLUIDA = 'CONCLUIDA', _('Concluida')
    CANCELADA = 'CANCELADA', _('Cancelada')


class Usuario(PolymorphicModel, models.Model):
    ''''''

    nome = models.CharField(max_length=300, null=True, blank=True)
    _email = models.EmailField(null=True, blank=True)
    senha = models.CharField(max_length=300, null=True, blank=True)



    class Meta:
        db_table = 'usuario'

class Categoria(PolymorphicModel, models.Model):
    ''''''

    nome = models.CharField(max_length=300, null=True, blank=True)


    usuario = models.ForeignKey(Usuario, blank=True, null=True, on_delete=models.CASCADE, related_name="usuario_%(class)s")

    class Meta:
        db_table = 'categoria'

class Tarefa(PolymorphicModel, models.Model):
    ''''''

    titulo = models.CharField(max_length=300, null=True, blank=True)
    descricao = models.CharField(max_length=300, null=True, blank=True)
    data_vencimento = models.DateField(null=True, blank=True)

    prioridade = models.CharField(max_length=5, choices=Prioridade.choices, default=Prioridade.BAIXA)
    status = models.CharField(max_length=9, choices=Status.choices, default=Status.PENDENTE)

    categoria = models.ForeignKey(Categoria, blank=True, null=True, on_delete=models.CASCADE, related_name="categoria_%(class)s")
    usuario = models.ForeignKey(Usuario, blank=True, null=True, on_delete=models.CASCADE, related_name="usuario_%(class)s")

    class Meta:
        db_table = 'tarefa'

