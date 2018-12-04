--
-- PostgreSQL database dump
--

-- Dumped from database version 10.5
-- Dumped by pg_dump version 10.5

-- Started on 2018-12-04 19:13:49

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 2199 (class 1262 OID 24706)
-- Name: implan; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE implan WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Portuguese_Brazil.1252' LC_CTYPE = 'Portuguese_Brazil.1252';


ALTER DATABASE implan OWNER TO postgres;

\connect implan

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 1 (class 3079 OID 12278)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2201 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 197 (class 1259 OID 24709)
-- Name: ambiente; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ambiente (
    codigo_ambiente integer NOT NULL,
    nome_ambiente character varying(15) NOT NULL
);


ALTER TABLE public.ambiente OWNER TO postgres;

--
-- TOC entry 196 (class 1259 OID 24707)
-- Name: ambiente_codigo_ambiente_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ambiente_codigo_ambiente_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ambiente_codigo_ambiente_seq OWNER TO postgres;

--
-- TOC entry 2202 (class 0 OID 0)
-- Dependencies: 196
-- Name: ambiente_codigo_ambiente_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ambiente_codigo_ambiente_seq OWNED BY public.ambiente.codigo_ambiente;


--
-- TOC entry 201 (class 1259 OID 24730)
-- Name: categoria; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.categoria (
    codigo_categoria integer NOT NULL,
    nome_categoria character varying(15) NOT NULL
);


ALTER TABLE public.categoria OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 24728)
-- Name: categoria_codigo_categoria_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.categoria_codigo_categoria_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.categoria_codigo_categoria_seq OWNER TO postgres;

--
-- TOC entry 2203 (class 0 OID 0)
-- Dependencies: 200
-- Name: categoria_codigo_categoria_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.categoria_codigo_categoria_seq OWNED BY public.categoria.codigo_categoria;


--
-- TOC entry 203 (class 1259 OID 24738)
-- Name: item_conf; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.item_conf (
    codigo_ic integer NOT NULL,
    codigo_ambiente integer,
    codigo_categoria integer,
    nome_ic character varying(15) NOT NULL
);


ALTER TABLE public.item_conf OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 24736)
-- Name: item_conf_codigo_ic_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.item_conf_codigo_ic_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.item_conf_codigo_ic_seq OWNER TO postgres;

--
-- TOC entry 2204 (class 0 OID 0)
-- Dependencies: 202
-- Name: item_conf_codigo_ic_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.item_conf_codigo_ic_seq OWNED BY public.item_conf.codigo_ic;


--
-- TOC entry 199 (class 1259 OID 24717)
-- Name: plano; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.plano (
    codigo_plano integer NOT NULL,
    codigo_ambiente integer,
    codigo_atividade character varying(10),
    nome_plano character varying(50) NOT NULL,
    data_inicio timestamp without time zone NOT NULL,
    data_fim timestamp without time zone NOT NULL,
    status boolean
);


ALTER TABLE public.plano OWNER TO postgres;

--
-- TOC entry 198 (class 1259 OID 24715)
-- Name: plano_codigo_plano_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.plano_codigo_plano_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.plano_codigo_plano_seq OWNER TO postgres;

--
-- TOC entry 2205 (class 0 OID 0)
-- Dependencies: 198
-- Name: plano_codigo_plano_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.plano_codigo_plano_seq OWNED BY public.plano.codigo_plano;


--
-- TOC entry 204 (class 1259 OID 24754)
-- Name: plano_inst; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.plano_inst (
    codigo_plano integer,
    codigo_inst integer NOT NULL,
    codigo_categoria integer,
    desc_inst character varying(100) NOT NULL,
    comando text,
    status boolean,
    nota text,
    tempo_est time without time zone
);


ALTER TABLE public.plano_inst OWNER TO postgres;

--
-- TOC entry 2047 (class 2604 OID 24712)
-- Name: ambiente codigo_ambiente; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ambiente ALTER COLUMN codigo_ambiente SET DEFAULT nextval('public.ambiente_codigo_ambiente_seq'::regclass);


--
-- TOC entry 2049 (class 2604 OID 24733)
-- Name: categoria codigo_categoria; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categoria ALTER COLUMN codigo_categoria SET DEFAULT nextval('public.categoria_codigo_categoria_seq'::regclass);


--
-- TOC entry 2050 (class 2604 OID 24741)
-- Name: item_conf codigo_ic; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.item_conf ALTER COLUMN codigo_ic SET DEFAULT nextval('public.item_conf_codigo_ic_seq'::regclass);


--
-- TOC entry 2048 (class 2604 OID 24720)
-- Name: plano codigo_plano; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.plano ALTER COLUMN codigo_plano SET DEFAULT nextval('public.plano_codigo_plano_seq'::regclass);


--
-- TOC entry 2186 (class 0 OID 24709)
-- Dependencies: 197
-- Data for Name: ambiente; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.ambiente VALUES (1, 'DESENVOLVIMENTO');
INSERT INTO public.ambiente VALUES (2, 'TESTE');
INSERT INTO public.ambiente VALUES (3, 'ACEITAÇÃO');
INSERT INTO public.ambiente VALUES (4, 'PRODUÇÃO');
INSERT INTO public.ambiente VALUES (5, 'CDS PRODUÇÂO');


--
-- TOC entry 2190 (class 0 OID 24730)
-- Dependencies: 201
-- Data for Name: categoria; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.categoria VALUES (1, 'APP SERVER');
INSERT INTO public.categoria VALUES (2, 'WEB SERVER');
INSERT INTO public.categoria VALUES (3, 'BATCH SERVER');


--
-- TOC entry 2192 (class 0 OID 24738)
-- Dependencies: 203
-- Data for Name: item_conf; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.item_conf VALUES (1, 4, 1, 'PRODAPP1');
INSERT INTO public.item_conf VALUES (2, 4, 2, 'PRODVM1');
INSERT INTO public.item_conf VALUES (3, 4, 2, 'PRODVM2');
INSERT INTO public.item_conf VALUES (4, 4, 3, 'PRODBATCH1');
INSERT INTO public.item_conf VALUES (5, 4, 3, 'PRODBATCH2');
INSERT INTO public.item_conf VALUES (6, 4, 3, 'PRODBATCH3');
INSERT INTO public.item_conf VALUES (7, 4, 3, 'PRODBATCH4');
INSERT INTO public.item_conf VALUES (8, 4, 3, 'PRODBATCH5');
INSERT INTO public.item_conf VALUES (9, 4, 3, 'PRODBATCH6');
INSERT INTO public.item_conf VALUES (10, 5, 2, 'PVMKE790');
INSERT INTO public.item_conf VALUES (11, 5, 1, 'PVMKE792');
INSERT INTO public.item_conf VALUES (12, 5, 3, 'PVMKE799');


--
-- TOC entry 2188 (class 0 OID 24717)
-- Dependencies: 199
-- Data for Name: plano; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.plano VALUES (2, 4, 'C233455', 'CHANGE WEBSERVICES CONFIG', '2018-11-21 01:00:00', '2018-11-21 01:46:00', false);
INSERT INTO public.plano VALUES (3, 4, 'C021189', 'INSTALAÇÃO BATCH', '2018-11-20 01:30:00', '2018-11-20 02:06:00', false);
INSERT INTO public.plano VALUES (4, 5, 'C092929', 'CDS SO UPGRADE', '2018-11-24 02:00:00', '2018-11-24 03:52:00', false);
INSERT INTO public.plano VALUES (1, 4, 'C067078', 'DEPLOY QUERYCUSTOMERINFO', '2018-11-20 02:00:00', '2018-11-20 02:26:00', false);
INSERT INTO public.plano VALUES (5, 5, 'GBL18110', 'IMPLANTAÇÃO INTLVOICECALLFULLREPORT.SH (PVMKE799) ', '2018-11-25 01:00:00', '2018-11-25 02:40:00', false);


--
-- TOC entry 2193 (class 0 OID 24754)
-- Dependencies: 204
-- Data for Name: plano_inst; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.plano_inst VALUES (3, 2, 3, 'LOGIN NO SERVIDORES', 'login nos servidores afetados', false, '', '00:00:00');
INSERT INTO public.plano_inst VALUES (2, 3, 2, 'EXECUTAR MENU DA APLICAÇÃO', 'menu', false, 'alias para o menu da aplicação', '00:02:00');
INSERT INTO public.plano_inst VALUES (2, 2, 2, 'LOGIN COMO WEBADMIN', 'sudo su - webadmin', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (2, 4, 2, 'PARAR AS APIS DO SERVIDOR', '(2)  STOP: API -> (A) ALL_APIs
', false, '', '00:10:00');
INSERT INTO public.plano_inst VALUES (2, 5, 2, 'PARAR A WEBSERVICES INTERFACE', '(10) STOP: WEBSERVICES-INTERFACE
', false, '', '00:05:00');
INSERT INTO public.plano_inst VALUES (2, 6, 2, 'IR PARA DIRETÓRIO DE CONFIGURAÇÃO', 'cd /tools/webservices-interface/conf
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (2, 7, 2, 'BACKUP DA CONFIGURAÇÃO ATUAL', 'mv web.conf web.conf.bkp
', false, 'Cria um backup do arquivo de configuração atual
', '00:02:00');
INSERT INTO public.plano_inst VALUES (2, 8, 2, 'APLICAR NOVA CONFIGURAÇÃO', 'mv stage/web.conf .
', false, 'Copia o novo arquivo de configuração para o diretório atual
', '00:02:00');
INSERT INTO public.plano_inst VALUES (2, 9, 2, 'VOLTAR AO /HOME DO WEBADMIN', 'cd', false, 'retorna para o /home do webadmin
', '00:02:00');
INSERT INTO public.plano_inst VALUES (2, 10, 2, 'EXECUTAR O MENU DA APLICAÇÃO', 'menu', false, 'alias para o menu da aplicação', '00:02:00');
INSERT INTO public.plano_inst VALUES (2, 11, 2, 'INICIAR A WEBSERVICES INTERFACE', '(11) START: WEBSERVICES-INTERFACE
', false, '', '00:05:00');
INSERT INTO public.plano_inst VALUES (2, 12, 2, 'INICIAR AS APIS DO SERVIDOR', '(3)  START: API -> (A) ALL_APIs
', false, '', '00:10:00');
INSERT INTO public.plano_inst VALUES (3, 6, 3, 'DESCOMPACTAR ARQUIVOS', 'tar -xvf NMS_AMPLERO.tar', false, 'untar dos arquivos
', '00:01:00');
INSERT INTO public.plano_inst VALUES (3, 7, 3, 'CRIAR DIRETÓRIO DE SAÍDA', 'mkdir -p /logs/nms/production/batch/NMS_AMPLERO/output/
', false, '', '00:01:00');
INSERT INTO public.plano_inst VALUES (3, 8, 3, 'MUDAR PERMISSÕES DO DIRETORIO DE SAÍDA', 'chmod 777 /logs/nms/production/batch/NMS_AMPLERO/output/
', false, 'Para que o receptor possa excluir o arquivo após transferido
', '00:01:00');
INSERT INTO public.plano_inst VALUES (4, 16, 1, 'EXTERNALWS DOWN', ' sudo -u tppadmin /tools/jboss/cds/pvmke792/cds-production-externalws1/bin/admin.sh stop
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (3, 5, 3, 'COPIAR ARQUIVOS', 'cp /tmp/MID16.3/NMS_AMPLERO.tar ./
', false, 'copiar arquivos da implantação', '00:01:00');
INSERT INTO public.plano_inst VALUES (3, 4, 3, 'IR PARA O DIRETORIO BATCH', 'nmsbatch', false, 'alias para ''/production/nms/batch''', '00:01:00');
INSERT INTO public.plano_inst VALUES (3, 3, 3, 'MUDAR USUARIO PARA WEBADMIN', 'sudo su - webadmin', false, '', '00:01:00');
INSERT INTO public.plano_inst VALUES (4, 17, 1, 'EAISERVICES DOWN', ' sudo -u tppadmin /tools/jboss/cds/pvmke792/cds-production-eaiservices1/bin/admin.sh stop', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (2, 1, 2, 'LOGIN NO SERVIDOR', 'login no servidor afetado', false, 'TODOS OS PASSOS DESSE PLANO DEVEM SER FEITOS EM UM SERVIDOR AFETADO POR VEZ, PARA EVITAR DOWNTIME NA APLICAÇÃO!!', '00:02:00');
INSERT INTO public.plano_inst VALUES (4, 18, 1, 'TIME DE HARDWARE PROSSEGUIR', 'Comunicar ao time de hardware para iniciar sua tarefa', false, 'Administradores do Sistema irão atualizar o Sistema Operacional do servidor', '00:30:00');
INSERT INTO public.plano_inst VALUES (4, 2, 2, 'EAI BALANCER', '/tools/httpd/cds-production/eai-balancer/bin/admin.sh stop
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (4, 1, 2, 'DESLIGAR LOAD BALANCERS', 'login no servidor
sudo su - webadmin	
', false, '', '00:00:00');
INSERT INTO public.plano_inst VALUES (4, 3, 2, 'EXT BALANCER', '/tools/httpd/cds-production/ext-balancer/bin/admin.sh stop
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (1, 6, 1, 'INSTALAR NOVA VERSÃO DA API', './deploy.sh queryCustomerInfo
', false, 'Executa o Script utilizado para instalar a nova versão do código, cujos arquivos estão no diretório STAGE
', '00:10:00');
INSERT INTO public.plano_inst VALUES (1, 7, 1, 'VOLTAR PARA O HOME DO WEBADMIN', 'cd', false, 'retorna para o /home do webadmin', '00:01:00');
INSERT INTO public.plano_inst VALUES (1, 8, 1, 'EXECUTAR MENU DA APLICAÇÃO', 'menu', false, 'alias para o menu da aplicação', '00:01:00');
INSERT INTO public.plano_inst VALUES (1, 9, 1, 'INICIAR API', '(3)  START: API -> (2) queryCustomerInfo
', false, 'Inicia a queryCustomerInfo em sua nova versão', '00:05:00');
INSERT INTO public.plano_inst VALUES (1, 1, 1, 'LOGIN NO SERVIDOR', 'Login no(s) servidor(es) afetado(s)', true, '', '00:01:00');
INSERT INTO public.plano_inst VALUES (1, 2, 1, 'LOGIN AS WEBADMIN', 'sudo su - webadmin', true, '', '00:01:00');
INSERT INTO public.plano_inst VALUES (1, 3, 1, 'EXECUTAR MENU DA APLICAÇÃO', 'menu', true, 'alias para o menu da aplicação', '00:01:00');
INSERT INTO public.plano_inst VALUES (1, 4, 1, 'DESLIGAR API', '(2)  STOP: API -> (2) queryCustomerInfo', true, 'Desliga a queryCustomerInfo', '00:05:00');
INSERT INTO public.plano_inst VALUES (1, 5, 1, 'MUDAR PARA DIRETÓRIO DA APP', 'cd /production/A', true, 'Muda para o diretório de instalação das APIs
', '00:01:00');
INSERT INTO public.plano_inst VALUES (4, 4, 2, 'INT BALANCER', '/tools/httpd/cds-production/int-balancer/bin/admin.sh stop
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (3, 1, 3, 'INSTRUÇÕES BÁSICAS / PREPARAÇÃO', '- Verificar seu acesso aos servidores afetados nesta atividade	
- Verificar se seu ambiente contém espaço em disco o suficiente para receber a atualização	
- Verificar se nada além do pacote de código está no diretório INSTALL	
', false, '', '00:30:00');
INSERT INTO public.plano_inst VALUES (4, 6, 2, 'SSO BALANCER', '/tools/httpd/cds-production/sso-balancer/bin/admin.sh stop
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (4, 5, 2, 'SSF BALANCER', '/tools/httpd/cds-production/ssf-balancer/bin/admin.sh stop', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (4, 7, 2, 'TIME DE HARDWARE PROSSEGUIR', 'Comunicar ao time de hardware para iniciar sua tarefa', false, 'Administradores do sistema irão realizar o upgrade do Sistema Operacional', '00:30:00');
INSERT INTO public.plano_inst VALUES (4, 8, 2, 'REINICIAR LOAD BALANCERS', 'login no servidor
sudo su - webadmin', false, '', '00:00:00');
INSERT INTO public.plano_inst VALUES (4, 9, 2, 'EAI BALANCER UP', '/tools/httpd/cds-production/eai-balancer/bin/admin.sh start
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (4, 10, 2, 'EXT BALANCER UP', '/tools/httpd/cds-production/ext-balancer/bin/admin.sh start
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (4, 11, 2, 'INT BALANCER UP', '/tools/httpd/cds-production/int-balancer/bin/admin.sh start
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (4, 12, 2, 'SSF BALANCER UP ', '/tools/httpd/cds-production/ssf-balancer/bin/admin.sh start
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (4, 13, 2, 'SSO BALANCER UP', '/tools/httpd/cds-production/sso-balancer/bin/admin.sh start
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (4, 14, 1, 'DESLIGAR JBOSS', 'login no servidor', false, '', '00:00:00');
INSERT INTO public.plano_inst VALUES (4, 15, 1, 'INTERNALWS DOWN', ' sudo -u tppadmin /tools/jboss/cds/pvmke792/cds-production-internalws1/bin/admin.sh stop
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (4, 19, 1, 'REINICIAR JBOSS', 'login no servidor', false, '', '00:00:00');
INSERT INTO public.plano_inst VALUES (4, 20, 1, 'INTERNALWS UP', ' sudo -u tppadmin /tools/jboss/cds/pvmke792/cds-production-internalws1/bin/admin.sh start clean
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (4, 21, 1, 'EXTERNALWS UP', ' sudo -u tppadmin /tools/jboss/cds/pvmke792/cds-production-externalws1/bin/admin.sh start clean
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (4, 22, 1, 'EAISERVICES UP', ' sudo -u tppadmin /tools/jboss/cds/pvmke792/cds-production-eaiservices1/bin/admin.sh start clean
', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (4, 23, 1, 'REALIZAR TESTE DE SANIDADE', 'Verificar se todas as unidades do sistema estão funcionando corretamente ', false, '', '00:20:00');
INSERT INTO public.plano_inst VALUES (5, 1, 3, 'BACKUP DA APP', 'realizar o backup da app
login pvmke799
sudo su - cdsadmin', false, '', '00:02:00');
INSERT INTO public.plano_inst VALUES (5, 2, 3, 'LIMPAR BACKUPS ANTIGOS', 'cd /data/cds/data
Limpar backups de implantações anteriores para liberar espaço
', false, '', '00:22:00');
INSERT INTO public.plano_inst VALUES (5, 3, 3, 'CRIAR DIRETORIO DE BACKUP', 'mkdir -p /data/cds/data/GBL18110/backup
', false, '', '00:01:00');
INSERT INTO public.plano_inst VALUES (5, 4, 3, 'TAR DA APP - BACKUP', 'cd /production
tar czvf /data/cds/data/GBL18110/backup/production_deployment_backup_20181125.tgz cds
', false, 'Rodar os comandos acima para realizar o backup da aplicação atual', '00:35:00');
INSERT INTO public.plano_inst VALUES (5, 5, 3, 'INSTALAR PACOTE', 'login pvmke799
sudo su - cdsadmin', false, '', '00:00:00');
INSERT INTO public.plano_inst VALUES (5, 6, 3, 'SETUP N SCRIPTS', '. ~intadmin/nscripts/setup
', false, 'comando para configurar o N scripts da app', '00:00:00');
INSERT INTO public.plano_inst VALUES (5, 7, 3, 'INSTALAR CODIGO', 'cd /production/cds	
n cds install CDS-GBL18110-b04.zip full	
', false, 'Instalação do código no diretório adequado', '00:15:00');
INSERT INTO public.plano_inst VALUES (5, 8, 3, 'IR PARA O DIRETORIO DO SCRIPT', 'cd /production/cds/cdpm/scripts
', false, 'move para o diretorio onde o script foi instalado', '00:00:00');
INSERT INTO public.plano_inst VALUES (5, 9, 3, 'EXECUTAR SCRIPT', 'nohup ./IntlVoiceCallFullReport.sh > /tmp/IntlVoiceCallFullReport.out 2>&1
', false, '', '00:25:00');


--
-- TOC entry 2206 (class 0 OID 0)
-- Dependencies: 196
-- Name: ambiente_codigo_ambiente_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ambiente_codigo_ambiente_seq', 5, true);


--
-- TOC entry 2207 (class 0 OID 0)
-- Dependencies: 200
-- Name: categoria_codigo_categoria_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.categoria_codigo_categoria_seq', 3, true);


--
-- TOC entry 2208 (class 0 OID 0)
-- Dependencies: 202
-- Name: item_conf_codigo_ic_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.item_conf_codigo_ic_seq', 12, true);


--
-- TOC entry 2209 (class 0 OID 0)
-- Dependencies: 198
-- Name: plano_codigo_plano_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.plano_codigo_plano_seq', 6, true);


--
-- TOC entry 2052 (class 2606 OID 24714)
-- Name: ambiente ambiente_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ambiente
    ADD CONSTRAINT ambiente_pkey PRIMARY KEY (codigo_ambiente);


--
-- TOC entry 2056 (class 2606 OID 24735)
-- Name: categoria categoria_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.categoria
    ADD CONSTRAINT categoria_pkey PRIMARY KEY (codigo_categoria);


--
-- TOC entry 2058 (class 2606 OID 24743)
-- Name: item_conf item_conf_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.item_conf
    ADD CONSTRAINT item_conf_pkey PRIMARY KEY (codigo_ic);


--
-- TOC entry 2054 (class 2606 OID 24722)
-- Name: plano plano_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.plano
    ADD CONSTRAINT plano_pkey PRIMARY KEY (codigo_plano);


--
-- TOC entry 2060 (class 2606 OID 24744)
-- Name: item_conf item_conf_codigo_ambiente_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.item_conf
    ADD CONSTRAINT item_conf_codigo_ambiente_fkey FOREIGN KEY (codigo_ambiente) REFERENCES public.ambiente(codigo_ambiente);


--
-- TOC entry 2061 (class 2606 OID 24749)
-- Name: item_conf item_conf_codigo_categoria_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.item_conf
    ADD CONSTRAINT item_conf_codigo_categoria_fkey FOREIGN KEY (codigo_categoria) REFERENCES public.categoria(codigo_categoria);


--
-- TOC entry 2059 (class 2606 OID 24723)
-- Name: plano plano_codigo_ambiente_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.plano
    ADD CONSTRAINT plano_codigo_ambiente_fkey FOREIGN KEY (codigo_ambiente) REFERENCES public.ambiente(codigo_ambiente);


--
-- TOC entry 2063 (class 2606 OID 24765)
-- Name: plano_inst plano_inst_codigo_categoria_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.plano_inst
    ADD CONSTRAINT plano_inst_codigo_categoria_fkey FOREIGN KEY (codigo_categoria) REFERENCES public.categoria(codigo_categoria);


--
-- TOC entry 2062 (class 2606 OID 24760)
-- Name: plano_inst plano_inst_codigo_plano_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.plano_inst
    ADD CONSTRAINT plano_inst_codigo_plano_fkey FOREIGN KEY (codigo_plano) REFERENCES public.plano(codigo_plano);


-- Completed on 2018-12-04 19:13:50

--
-- PostgreSQL database dump complete
--

