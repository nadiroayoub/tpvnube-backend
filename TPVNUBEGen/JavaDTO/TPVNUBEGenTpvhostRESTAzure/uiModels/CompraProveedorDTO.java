	
		package TPVNUBEGenTpvhostRESTAzure.uiModels.DTO;
		
		import java.util.ArrayList;
		
		import org.json.JSONArray;
		import org.json.JSONException;
		import org.json.JSONObject;
		import  TPVNUBEGenTpvhostRESTAzure.uiModels.DTO.utils.*;
		import  TPVNUBEGenTpvhostRESTAzure.uiModels.DTO.enumerations.*;
		
		
		/**
		 * Code autogenerated. Do not modify this file.
		 */
		
		
		public class CompraProveedorDTO 	    implements IDTO
	    {
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private ArrayList<LineaCompraProveedorDTO> lineaCompraProveedor;
				public ArrayList<LineaCompraProveedorDTO> getLineaCompraProveedor () { return lineaCompraProveedor; } 
				public void setLineaCompraProveedor (ArrayList<LineaCompraProveedorDTO> value) { lineaCompraProveedor = value;  } 
				    	 
				private Integer proveedor_oid;
				public Integer  getProveedor_oid () { return proveedor_oid; } 
				public void setProveedor_oid (Integer value) { proveedor_oid = value;  } 
				    	 
				private Integer negocio_oid;
				public Integer  getNegocio_oid () { return negocio_oid; } 
				public void setNegocio_oid (Integer value) { negocio_oid = value;  } 
				    	 
				private ArrayList<Integer> pago_oid;
				public ArrayList<Integer>  getPago_oid () { return pago_oid; } 
				public void setPago_oid (ArrayList<Integer> value) { pago_oid = value;  } 
				    	 
				private EstadoCompraProveedor estadoCompra;
				public EstadoCompraProveedor getEstadoCompra () { return estadoCompra; } 
				public void setEstadoCompra  (EstadoCompraProveedor value) { estadoCompra = value;  } 
				    	 
				private java.util.Date fecha;
				public java.util.Date getFecha () { return fecha; } 
				public void setFecha  (java.util.Date value) { fecha = value;  } 
				    	 
				private Double total;
				public Double getTotal () { return total; } 
				public void setTotal  (Double value) { total = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Id", this.id.intValue());
				

						if (this.lineaCompraProveedor != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.lineaCompraProveedor.size(); ++i)
							{
								jsonArray.put(this.lineaCompraProveedor.get(i).toJSON());
							}
							json.put("LineaCompraProveedor", jsonArray);
						}

						if (this.proveedor_oid != null)
						{
							json.put("Proveedor_oid", this.proveedor_oid.intValue());
						}

						if (this.negocio_oid != null)
						{
							json.put("Negocio_oid", this.negocio_oid.intValue());
						}

						if (this.pago_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.pago_oid.size(); ++i)
							{
								jsonArray.put(this.pago_oid.get(i));
							}
							json.put("Pago_oid", jsonArray);
						}
		
				
						  json.put("EstadoCompra", this.estadoCompra.getRawValue());
				
				
						  json.put("Fecha", DateUtils.dateToFormatString(this.fecha));
				
					    if (this.total != null){											
						  json.put("Total", this.total);
				
						}
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	